using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace WebMVCContacts.Models.Repo
{
    public class ContactRepo
    {
        public bool AddContact(ContactModel obj)
        {
            try
            {
                WcfClientRef.Service1Client ContactServiceClient = new WcfClientRef.Service1Client();
                ContactServiceClient.AddContact(obj.FName, obj.LName, obj.EmailId, Convert.ToString(obj.Status) );

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ContactModel> GetAllContacts()
        {
            List<ContactModel> ContactList = new List<ContactModel>();    
            try
            {
                WcfClientRef.Service1Client ContactServiceClient = new WcfClientRef.Service1Client();
                List<WcfClientRef.ContactModel> serviceContact = new List<WcfClientRef.ContactModel>();
                serviceContact = ContactServiceClient.GetContactList().ToList();
                foreach(WcfClientRef.ContactModel sc in serviceContact )
                {
                    ContactList.Add(
                        new ContactModel
                        {

                            Id = sc.Id,
                            FName = sc.FName,
                            LName = sc.LName,
                            EmailId = sc.EmailId
                           // Status = sc.Status
                        }
                       );
                }
                return  ContactList;
            }
            catch (Exception ex)
            {
                return ContactList;
            }
        }

        public bool UpdateContact(ContactModel obj)
        {
            try
            {
                WcfClientRef.Service1Client ContactServiceClient = new WcfClientRef.Service1Client();
                ContactServiceClient.UpateContact (obj.Id, obj.FName, obj.LName, obj.EmailId, Convert.ToString(obj.Status));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteContact(int id)
        {
            try
            {
                WcfClientRef.Service1Client ContactServiceClient = new WcfClientRef.Service1Client();
                ContactServiceClient.DeleteContact (id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}