namespace AccountManagementService.Dtos
{
	public class AccountReadDto
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionReadDto>? Transactions { get; set; }
    }
}

