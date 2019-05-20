using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class PrivPubKey
    {
        const string PRIVKEY_HEADER = "-----BEGIN RSA PRIVATE KEY-----";  //chưa xong!
        const string PRIVKEY_FOOTER = "-----END RSA PRIVATE KEY-----";

        public static string DecodeRSAPrivateKey(string textFromFile, string password)           //return xmlstring
        {
            if (IsPrivateKeyAvailable(textFromFile) == false)
                throw new ArgumentException("bad format");

            string temp = textFromFile;

            char[] charToTrim = { '\r', '\n', ' ' };
            string algorName = null;
            string iv = null;

            temp = temp.Replace(PRIVKEY_HEADER, "");
            temp = temp.Replace(PRIVKEY_FOOTER, "");
            //temp = temp.Replace("\r", "");
            //temp = temp.Replace("\n", "");
            temp = temp.Trim(charToTrim);
            if (temp.Contains("Proc-Type: 4,ENCRYPTED"))
            {
                temp = temp.Replace("Proc-Type: 4,ENCRYPTED", "");
                temp = temp.Trim(charToTrim);
                if (temp.Contains("DEK-Info:"))
                {
                    int idx_1stnewline = temp.IndexOf("\n");
                    string firstline = temp.Substring(0, idx_1stnewline);
                    temp = temp.Replace(firstline, "");
                    temp = temp.Trim(charToTrim);

                    firstline = firstline.Replace("DEK-Info: ", "");
                    firstline = firstline.Trim(charToTrim);
                    string[] infoDecrypt = firstline.Split(new char[] { ',', ' ' });
                    algorName = infoDecrypt[0]; iv = infoDecrypt[1];
                }
            }
            temp = temp.Replace("\r", "");
            temp = temp.Replace("\n", "");

            byte[] privateKeyInDER = Convert.FromBase64String(temp);
            string xmlString;
            //Decrypt
            if (algorName != null)
            {
                //byte[] decryptedData;
                SymmetricAlgorithm decrypter = null;
                byte[] key = null;
                if (algorName.Contains("AES"))
                {
                    decrypter = new AesCryptoServiceProvider();
                    
                }
                if (algorName.Contains("CBC")) decrypter.Mode = CipherMode.CBC;

                if (algorName.Contains("256"))
                {
                    decrypter.KeySize = 256;
                    using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
                    {
                        key = sha256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    }
                }
                else if (algorName.Contains("128"))
                {
                    decrypter.KeySize = 128;
                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    }
                }
                ICryptoTransform dec = decrypter.CreateDecryptor(key, hexStringToByte(iv));

                //byte[] decryptedData = dec.TransformFinalBlock(privateKeyInDER, 0, privateKeyInDER.Length);
                //xmlString = ASCIIEncoding.ASCII.GetString(decryptedData);

                using (MemoryStream ms = new MemoryStream(privateKeyInDER))
                {
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs)) xmlString = sr.ReadToEnd();
                    }
                }

                decrypter.Dispose();
                //xmlString = ASCIIEncoding.ASCII.GetString(decryptedData);
            }
            else xmlString = ASCIIEncoding.ASCII.GetString(privateKeyInDER);
            return xmlString;
        }

        public static string GenerateEncryptedPrivFile(string xmlstring, string uname, string password = null, string algorname = null)
        {
            byte[] encryptedData;
            string ivstring = null;
            if (algorname != null)
            {
                SymmetricAlgorithm encrypter = null;
                byte[] key = null;
                if (algorname.Contains("AES"))
                {
                    encrypter = new AesCryptoServiceProvider();

                }
                if (algorname.Contains("CBC")) encrypter.Mode = CipherMode.CBC;

                if (algorname.Contains("256"))
                {
                    encrypter.KeySize = 256;
                    using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
                    {
                        key = sha256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    }
                }
                else if (algorname.Contains("128"))
                {
                    encrypter.KeySize = 128;
                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    }
                }
                encrypter.Key = key;
                encrypter.GenerateIV();
                ICryptoTransform enc = encrypter.CreateEncryptor();

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(xmlstring);
                    }
                    encryptedData = ms.ToArray();
                }
                ivstring = byteToHexString(encrypter.IV);

            }
            else encryptedData = ASCIIEncoding.ASCII.GetBytes(xmlstring);

            try
            {
                string filename = @"PrivK\" + uname + ".encprk";
                StreamWriter fout = new StreamWriter(filename); //User's encrypted private key file. It will be stored temporarily in another client app's folder
                fout.WriteLine(PRIVKEY_HEADER);
                if (algorname != null)
                {
                    fout.WriteLine("Proc-Type: 4,ENCRYPTED");
                    fout.WriteLine("DEK-Info: {0}, {1}", algorname, ivstring);
                    fout.WriteLine();

                }
                string b64st = Convert.ToBase64String(encryptedData);
                int len = b64st.Length;
                for (int split64index = 0; split64index < len; split64index += 64)
                {
                    fout.WriteLine(b64st.Substring(split64index, 64));
                }
                fout.WriteLine(PRIVKEY_FOOTER);

                fout.Close();

                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static bool IsPrivateKeyAvailable(string privateKeyInPEM)
        {
            return (privateKeyInPEM != null && privateKeyInPEM.Contains(PRIVKEY_HEADER)
                && privateKeyInPEM.Contains(PRIVKEY_FOOTER));
        }

        private static byte[] hexStringToByte(string hexstring)
        {
            // i variable used to hold position in string  
            int i = 0;
            // x variable used to hold byte array element position  
            int x = 0;
            // allocate byte array based on half of string length  
            byte[] bytes = new byte[(hexstring.Length) / 2];
            // loop through the string - 2 bytes at a time converting it to decimal equivalent
            // and store in byte array  
            while (hexstring.Length > i + 1)
            {
                long lngDecimal = Convert.ToInt32(hexstring.Substring(i, 2), 16);
                bytes[x] = Convert.ToByte(lngDecimal);
                i = i + 2;
                ++x;
            }
            // return the finished byte array of decimal values  
            return bytes;
        }

        private static string byteToHexString(byte[] inputbyte)
        {
            // convert the byte array back to a true string  
            string strTemp = "";
            for (int x = 0; x <= inputbyte.GetUpperBound(0); x++)
            {
                int number = int.Parse(inputbyte[x].ToString());
                strTemp += number.ToString("X").PadLeft(2, '0');
            }
            // return the finished string of hex values  
            return strTemp;
        }
    }
}
