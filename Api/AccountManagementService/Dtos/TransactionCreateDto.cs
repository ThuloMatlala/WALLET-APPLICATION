using AccountManagementService.Models;

namespace AccountManagementService.Dtos
{
	public class TransactionCreateDto
    {
        public int Amount { get; set; }
        public int AccountId { get; set; }
        public string TransactionType { get; set; }
    }
}

