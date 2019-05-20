using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//using System.Security.Authentication;

namespace MailClient
{
    class CryptoFunctions
    {
        public static byte[] RSAEncrypt(byte[] data, RSAParameters RSAKey, bool doOAEPpadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider Rsa = new RSACryptoServiceProvider())
                {
                    Rsa.ImportParameters(RSAKey);
                    encryptedData = Rsa.Encrypt(data, doOAEPpadding);
                }
                return encryptedData;
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] data, RSAParameters RSAKey, bool doOAEPpadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider Rsa = new RSACryptoServiceProvider())
                {
                    Rsa.ImportParameters(RSAKey);
                    decryptedData = Rsa.Decrypt(data, doOAEPpadding);
                }
                return decryptedData;
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public static byte[] AESEncrypt(byte[] data, byte[] aeskey, byte[] iv)
        {
            try
            {
                byte[] encryptedData;
                using (AesManaged aes = new AesManaged())
                {
                    ICryptoTransform encryptor = aes.CreateEncryptor(aeskey, iv);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                                sw.Write(data);
                            encryptedData = ms.ToArray();
                        }
                    }
                }
                return encryptedData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static byte[] AESDecrypt(byte[] data, byte[] aeskey, byte[] iv)
        {
            try
            {
                byte[] decryptedData;
                string temp;
                using (AesManaged aes = new AesManaged())
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(aeskey, iv);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                                temp = sr.ReadToEnd();
                        }
                    }
                }
                decryptedData = Encoding.Unicode.GetBytes(temp);
                return decryptedData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        
        public static byte[] ComputeSHA256hash(byte[] data)
        {
            try
            {
                byte[] digest;
                using (SHA256 sha2 = SHA256.Create())
                {
                    digest = sha2.ComputeHash(data);
                }
                return digest;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static byte[] RSASign(byte[] dataToSign, RSAParameters RSAKey, object hashAlgor)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(RSAKey);

                //Hash and sign
                return RSAalg.SignData(dataToSign, hashAlgor);   //default hashAlgor is SHA256
            }
            catch (CryptographicException ex)
            {
                throw ex;
                return null;
            }
        }
        
        public static bool RSAVerify(byte[] dataToVerify, byte[] signeddata, RSAParameters RSAKey, object hashAlgor)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportParameters(RSAKey);
                
                //Verify
                return RSAalg.VerifyData(dataToVerify, hashAlgor, signeddata);
            }
            catch (CryptographicException ex)
            {
                //Console.WriteLine(ex.Message);
                throw ex;
                return false;
            }
        }
    }
}
