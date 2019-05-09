using CERTENROLLLib;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MailCryptAPI.Business
{
    public class ServerCert
    {
        //[DllImport("certenroll.dll")]
        //public static extern class CX500DistinguishedName;

        public static X509Certificate2 CreateSelfSignedCertificate(string subjectName, TimeSpan expirationLength)
        {
            //Create DN for subject and issuer
            var dn = new CX500DistinguishedName();
            dn.Encode("CN=" + subjectName, X500NameFlags.XCN_CERT_NAME_STR_NONE);
            
            CX509PrivateKey privateKey = new CX509PrivateKey();
            privateKey.ProviderName = "Microsoft Strong Cryptographic Provider";
            privateKey.Length = 2048;
            privateKey.KeySpec = X509KeySpec.XCN_AT_KEYEXCHANGE;
            privateKey.KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_DECRYPT_FLAG | X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_KEY_AGREEMENT_FLAG;
            privateKey.MachineContext = true;
            privateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG;
            privateKey.Create();

            // Use the stronger SHA512 hashing algorithm
            var hashobj = new CObjectId();
            hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
                ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
                AlgorithmFlags.AlgorithmFlagsNone, "SHA512");

            // Create the self signing request
            var cert = new CX509CertificateRequestCertificate();
            cert.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextMachine, privateKey, "");
            cert.Subject = dn;
            cert.Issuer = dn; // the issuer and the subject are the same
            cert.NotBefore = DateTime.Now.Date;
            // this cert expires immediately. Change to whatever makes sense for you
            cert.NotAfter = cert.NotBefore + expirationLength;
            cert.HashAlgorithm = hashobj; // Specify the hashing algorithm
            cert.Encode(); // encode the certificate
            
            // Do the final enrollment process
            var enroll = new CX509Enrollment();
            enroll.InitializeFromRequest(cert); // load the certificate
            enroll.CertificateFriendlyName = subjectName; // Optional: add a friendly name
            string csr = enroll.CreateRequest(); // Output the request in base64
                                                 // and install it back as the response
            enroll.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate,
                csr, EncodingType.XCN_CRYPT_STRING_BASE64, ""); // no password
                                                                // output a base64 encoded PKCS#12 so we can import it back to the .Net security classes
            var base64encoded = enroll.CreatePFX("", // no password, this is for internal consumption
                PFXExportOptions.PFXExportChainWithRoot);

            // instantiate the target class with the PKCS#12 data (and the empty password)
            return new X509Certificate2(Convert.FromBase64String(base64encoded), "",
                // mark the private key as exportable (this is usually what you want to do)
                // mark private key to go into the Machine store instead of the current users store
                X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet
            );
        }

        private static X509Certificate2 LoadCertFromStore(string serialNumber)
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.MaxAllowed);
            try
            {
                // serialnumber from certenroll.dll v6 is a base64 encoded byte array, which is reversed.
                // serialnumber from certenroll.dll v10 is a base64 encoded byte array, which is NOT reversed.
                var serialBytes = Convert.FromBase64String(serialNumber);
                var serial = BitConverter.ToString(serialBytes.ToArray()).Replace("-", "");
                var serialReversed = BitConverter.ToString(serialBytes.Reverse().ToArray()).Replace("-", "");

                var serverCerts = store.Certificates.Find(X509FindType.FindBySerialNumber, serial, false);
                if (serverCerts.Count == 0)
                {
                    serverCerts = store.Certificates.Find(X509FindType.FindBySerialNumber, serialReversed, false);
                }
                if (serverCerts.Count == 0)
                {
                    throw new KeyNotFoundException("No certificate with serial number <" + serial + "> or reversed serial <" + serialReversed + "> found!");
                }
                if (serverCerts.Count > 1)
                {
                    throw new Exception("Found multiple certificates with serial <" + serial + "> or reversed serial <" + serialReversed + ">!");
                }
                
                return serverCerts[0];
            }
            finally
            {
                store.Close();
            }
        }

        //cert = rsa.Key.CreateSelfSignedCertificate(new X500DistinguishedName("CN=something"));
    }
}