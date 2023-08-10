using AccountManagementService.Models;

namespace AccountManagementService.Data
{
	public class TransactionRepo : ITransactionRepo
    {
        private AppDbContext _context;
        public TransactionRepo(AppDbContext context)
        {
            _context = context;
        }


        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _context.Transactions.Add(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByAccountId(int accountId)
        {
            var transactions = _context.Transactions.Where(x => x.AccountId == accountId).ToList();
            return transactions;
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.FirstOrDefault(x => x.Id == transactionId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

