using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab28Tom.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime DestinyBirthday { get; set; }
    }
}
