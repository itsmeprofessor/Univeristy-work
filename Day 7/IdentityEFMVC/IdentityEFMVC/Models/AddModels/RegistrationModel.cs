using System.ComponentModel.DataAnnotations;

namespace IdentityEFMVC.Models.AddModels
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}