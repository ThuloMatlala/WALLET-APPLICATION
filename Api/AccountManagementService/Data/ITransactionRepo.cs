using AccountManagementService.Models;

namespace AccountManagementService.Data
{
	public interface ITransactionRepo
    {
        bool SaveChanges();
        Task<IEnumerable<Transaction>> GetAllTransactionsByAccountId(int accountId);
        Transaction GetTransactionById(int accountId);
        void CreateTransaction(Transaction transaction);
    }
}

