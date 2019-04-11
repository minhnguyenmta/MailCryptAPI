using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//using MailCryptAPI.DataServer;

namespace MailCryptAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailServer" in both code and config file together.
    [ServiceContract]
    public interface IMailServer
    {
        [OperationContract]
        string getPublicKey(string username);
    }
}
