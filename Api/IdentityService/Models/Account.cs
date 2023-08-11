using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
	public class Account
    {
        [Key]
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

