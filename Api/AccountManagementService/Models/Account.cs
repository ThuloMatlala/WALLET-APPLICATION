using System.ComponentModel.DataAnnotations;

namespace AccountManagementService.Models
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
        [Required]
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}

