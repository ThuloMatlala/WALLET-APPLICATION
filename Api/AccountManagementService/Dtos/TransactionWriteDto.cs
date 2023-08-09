using AccountManagementService.Models;

namespace AccountManagementService.Dtos
{
	public class TransactionWriteDto
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

