using System.ComponentModel.DataAnnotations;
namespace OtelMotel.MvcUI.Models
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Alani Zorunludur")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Sifre Zorunludur")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
