using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebMVCContacts.Models
{
   
    public class ContactModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email Id name is required.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "- Select Status -")]
        public StatusType Status { get; set; }

    }
    public enum StatusType
    {
        Active,
        Inactive
    }
}