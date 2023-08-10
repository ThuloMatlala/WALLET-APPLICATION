
namespace AccountManagementService.Dtos
{
	public class AccountCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionReadDto>? Transactions { get; set; }
    }
}

