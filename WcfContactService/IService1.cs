using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfContactService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<ContactModel> GetContactList();
        [OperationContract]
        string AddContact(string FName, string LName, string EmailId, string Status);

        [OperationContract]
        string UpateContact(int Id, string FName, string LName, string EmailId, string Status);
        [OperationContract]
        string DeleteContact(int Id);
    }

    [DataContract]
    public class ContactModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public string Status { get; set; }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
