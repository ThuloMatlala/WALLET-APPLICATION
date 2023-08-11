using AccountManagementService.Models;
using Microsoft.Identity.Client;

namespace AccountManagementService.Data
{
	public class AccountRepo : IAccountRepo
    {
        private AppDbContext _context;
        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentNullException(nameof(userAccount));
            }

            _context.Accounts.Add(userAccount);
        }

        public Account GetAccountDetails(int accountId)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == accountId);
        }

        public async Task<decimal> GetAccountsBalance(int userAccountId)
        {
            var account = GetAccountDetailsByUserAccount(userAccountId);
            return account == null ? default : account.Balance;
        }

        public void UpdateAccount(int userAccountId, Account account)
        {
            _context.Update(GetAccountDetailsByUserAccount(userAccountId));
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Account GetAccountDetailsByUserAccount(int userAccountId)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserAccountId == userAccountId);
        }
    }
}

