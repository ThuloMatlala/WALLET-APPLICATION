using AccountManagementService.Models;

namespace AccountManagementService.Data
{
	public interface IAccountRepo
    {
        bool SaveChanges();
        Account GetAccountDetailsByUserAccount(int accountId);
        Task<decimal> GetAccountsBalance(int accountId);
        void UpdateAccount(int accountId,Account account);
        void CreateAccount(Account account);
    }
}

