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

        public Stream sendSignInInfo(string username, string password)
        {
            throw new NotImplementedException();
            //return new FileStream("");
        }

        public void sendSignUpInfo(string username, string password, Stream publickey, Stream encryptedPrivatekey)
        {
            //Xử lý các stream và truy vấn

            publickey.Close();
            encryptedPrivatekey.Close();
        }

        public void sendEncryptedMail(string senderName)
        {
            throw new NotImplementedException();
        }


        //Chưa biết đặt đoạn code dưới đây ở đâu :-?
        //Cái này để bảo mật kết nối tcp
        //SslStream sslStream = new SslStream(serverCertificate, false, SslProtocols.Tls, true);
    }
}
