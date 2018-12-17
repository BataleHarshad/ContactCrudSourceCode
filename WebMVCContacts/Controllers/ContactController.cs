using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCContacts.Models;
using WebMVCContacts.Models.Repo;
namespace WebMVCContacts.Controllers
{
    public class ContactController : Controller
    {
   
        public ActionResult GetAllContactDetails()
        {

            ContactRepo ContactRepoObj = new ContactRepo();
            ModelState.Clear();
            return View(ContactRepoObj.GetAllContacts());
        }

        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(ContactModel ContactModelObj)
        {
            ContactRepo ContactRepoObj = new ContactRepo();
            try
            {
               
                if (ModelState.IsValid)
                {
                    if (ContactRepoObj.AddContact(ContactModelObj))
                    {
                        ViewBag.Message = "Contact details added successfully";
                    }
                }
                return RedirectToAction("GetAllContactDetails");
            }
            catch
            {
                return RedirectToAction("GetAllContactDetails");
            }
        }

        public ActionResult UpdateContact(int id)
        {
            ContactRepo ContactRepoObj = new ContactRepo();



            return View(ContactRepoObj.GetAllContacts().Find(Cont => Cont.Id == id));

        }    
        [HttpPost]
        public ActionResult UpdateContact(ContactModel ContactModelObj)
        {
            ContactRepo ContactRepoObj = new ContactRepo();
            try
            {

                if (ModelState.IsValid)
                {
                    if (ContactRepoObj.UpdateContact(ContactModelObj))
                    {
                        ViewBag.Message = "Contact details updated successfully";
                    }
                }
                return RedirectToAction("GetAllContactDetails");
            }
            catch
            {
                return RedirectToAction("GetAllContactDetails");
            }
        }
        public ActionResult DeleteContact(int id)
        {
            try
            {
                ContactRepo ContactRepoObj = new ContactRepo();
                if (ContactRepoObj.DeleteContact (id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllContactDetails");

            }
            catch
            {
                return RedirectToAction("GetAllContactDetails");
            }
        }    
  
    }
}
