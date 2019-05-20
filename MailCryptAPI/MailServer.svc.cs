using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MailCryptAPI.DataServer;
using System.Data;
using System.Net.Security;
using System.Security.Authentication;

namespace MailCryptAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MailServer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MailServer.svc or MailServer.svc.cs at the Solution Explorer and start debugging.
    public class MailServer : IMailServer
    {
        public bool signIn(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM User WHERE username = @username AND password = @password";   //đúng ra nên viết storedproc login
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { username, password });
            return (res.Rows[0][0].ToString() == "1");
        }

        public string getPublicKey(string username)
        {
            string query = "SELECT publickey FROM User WHERE username = @username";   //nên viết proc
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { username });
            string pubk = res.Rows[0]["publickey"].ToString();

            return pubk;
            //throw new NotImplementedException();
        }

        public Stream sendSignInInfo(string username, string password, out string fname)
        {
            fname = "";
            string query = "SELECT path FROM PrivateKey JOIN User ON PrivateKey.id = User.privkeyId WHERE username= @username AND password= @password ";
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { username, password });
            string path = res.Rows[0]["path"].ToString();
            fname = Path.GetFileName(path);

            return new FileStream(path, FileMode.Open, FileAccess.Read);
            //throw new NotImplementedException();
            //return new FileStream("");
        }

        public void sendSignUpInfo(string username, string password, string name, string publickey, Stream encryptedPrivatekey, string filename)
        {
            //Xử lý các stream và truy vấn
            string query1 = "INSERT INTO User VALUES ( @username , @password , @privkeyId , @publicKey )";
            Random rd = new Random();
            string keyID = "PRK" + rd.Next(1, 999).ToString().PadLeft(3, '0');
            SQLaccess.Instance.ExecuteNoneQuery(query1, new object[] { username, password, keyID, publickey });
            string path = @"D:\MailAPI\PrivK\" + filename;
            using (StreamReader sr = new StreamReader(encryptedPrivatekey))
            {
                string temp = sr.ReadToEnd();
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(temp);
                }
            }
            string query2 = "INSERT INTO PrivateKey VALUES ( @id , @path )";
            SQLaccess.Instance.ExecuteNoneQuery(query2, new object[] { keyID, path });

            encryptedPrivatekey.Close();
        }

        public void sendEncryptedMail(string recipientName, Stream sentMail, string filename, ReceivedMailInfo rmif)
        {
            //Save the mail
            string path = @"D:\MailAPI\Mail\" + filename;
            using (StreamReader sr = new StreamReader(sentMail))
            {
                string temp = sr.ReadToEnd();
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(temp);
                }
            }
            string query = "INSERT INTO Mail VALUES ( @mailID , @senderName , @recipientName , @title , @path )";
            SQLaccess.Instance.ExecuteNoneQuery(query, new object[] { rmif.mailID, rmif.senderName, recipientName, rmif.title, path });
            //throw new NotImplementedException();
        }

        public List<ReceivedMailInfo> getReceivedMailList(string recipientName)
        {
            List<ReceivedMailInfo> list = new List<ReceivedMailInfo>();
            string query = "SELECT senderName, title, mailID FROM Mail WHERE recipientName = @recipientName";
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { recipientName });
            foreach (DataRow dr in res.Rows)
            {
                ReceivedMailInfo rmif = new ReceivedMailInfo(dr);
                list.Add(rmif);
            }

            return list;
            //throw new NotImplementedException();
        }

        public Stream getMail(string mailID, out string fname)
        {
            fname = "";
            string query = "SELECT path FROM Mail WHERE mailID = @mailID";
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { mailID });
            string path = res.Rows[0]["publickey"].ToString();
            fname = Path.GetFileName(path);

            return new FileStream(path, FileMode.Open, FileAccess.Read);
            //throw new NotImplementedException();
        }

        //Chưa biết đặt đoạn code dưới đây ở đâu :-?
        //Cái này để bảo mật kết nối tcp
        //SslStream sslStream = new SslStream(serverCertificate, false, SslProtocols.Tls, true);
    }
}
