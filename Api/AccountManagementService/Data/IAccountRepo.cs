using AccountManagementService.Models;

namespace AccountManagementService.Data
{
	public interface IAccountRepo
    {
        bool SaveChanges();
        Account GetAccountDetails(int accountId);
        Task<decimal> GetAccountsBalance(int accountId);
        void UpdateAccount(int accountId,Account account);
    }
}

