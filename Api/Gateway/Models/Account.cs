using System.ComponentModel.DataAnnotations;

namespace Gateway.Models
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

