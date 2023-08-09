
namespace AccountManagementService.Dtos
{
	public class AccountWriteDto
    {
        public int UserAccountId { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionReadDto>? Transactions { get; set; }
    }
}

