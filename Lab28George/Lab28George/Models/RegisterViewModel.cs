using System.ComponentModel.DataAnnotations;

namespace Lab28George.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Please enter a valid password", MinimumLength = 10)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
