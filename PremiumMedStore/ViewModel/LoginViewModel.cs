using System.ComponentModel.DataAnnotations;

namespace PremiumMedStore.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
