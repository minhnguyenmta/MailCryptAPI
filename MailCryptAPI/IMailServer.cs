using System;
using System.Collections.Generic;
using System.Data;
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
        void sendSignUpInfo(string username, string password, string name, string publickey, Stream encryptedPrivatekey, string filename);

        [OperationContract]
        Stream sendSignInInfo(string username, string password, out string fname);

        [OperationContract]
        void sendEncryptedMail(string recipientName, Stream sentMail, string filename, ReceivedMailInfo rmif);

        [OperationContract]
        List<ReceivedMailInfo> getReceivedMailList(string recipientName);

        [OperationContract]
        Stream getMail(string mailID, out string fname);

        //[OperationContract]
        //Hàm lấy thư về để đọc
    }

    [DataContract]
    public class ReceivedMailInfo
    {
        public string mailID;
        public string senderName;
        public string title;

        public ReceivedMailInfo(string _id, string _sender, string _title)
        {
            this.mailID = _id;
            this.senderName = _sender;
            this.title = _title;
        }

        public ReceivedMailInfo(DataRow dr)
        {
            mailID = dr["mailID"].ToString();
            senderName = dr["senderName"].ToString();
            title = dr["title"].ToString();
        }

        [DataMember]
        public string mailIDps
        {
            get { return mailID; }
            set { mailID = value; }
        }

        [DataMember]
        public string senderNameDps
        {
            get { return senderName; }
            set { senderName = value; }
        }

        [DataMember]
        public string titleps
        {
            get { return title; }
            set { title = value; }
        }
    }
}
