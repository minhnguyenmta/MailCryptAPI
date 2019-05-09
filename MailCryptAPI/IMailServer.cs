using System;
using System.Collections.Generic;
using System.IO;
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
        bool signIn(string username, string password);

        [OperationContract]
        string getPublicKey(string username);

        [OperationContract]
        void sendSignUpInfo(string username, string password, Stream publickey, Stream encryptedPrivatekey);

        [OperationContract]
        Stream sendSignInInfo(string username, string password);

        [OperationContract]
        void sendEncryptedMail(string senderName);

        //[OperationContract]
        //Hàm lấy thư về để đọc
    }
}
