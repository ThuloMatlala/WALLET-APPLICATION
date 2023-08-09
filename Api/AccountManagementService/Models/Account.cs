using System.ComponentModel.DataAnnotations;

namespace AccountManagementService.Models
{
	public class Account
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserAccountId { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}

