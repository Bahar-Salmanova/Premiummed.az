using System.ComponentModel.DataAnnotations;

namespace PremiumMedStore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Token { get; set; }
    }
}
