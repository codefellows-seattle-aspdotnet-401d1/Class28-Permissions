using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab28George.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
