using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MailCryptAPI.DataServer;
using System.Data;

namespace MailCryptAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MailServer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MailServer.svc or MailServer.svc.cs at the Solution Explorer and start debugging.
    public class MailServer : IMailServer
    {
        public string getPublicKey(string username)
        {
            string query = "SELECT publickey FROM User WHERE username = ";
            DataTable res = SQLaccess.Instance.ExecuteQuery(query, new object[] { username });
            string pubk = res.Rows[0]["publickey"].ToString();

            return pubk;
            //throw new NotImplementedException();
        }
    }
}
