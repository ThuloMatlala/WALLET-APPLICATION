namespace AccountManagementService.Dtos
{
	public class TransactionReadDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
    }
}

