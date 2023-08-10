using AccountManagementService.Models;

namespace AccountManagementService.Data
{
	public class AccountRepo : IAccountRepo
    {
        private AppDbContext _context;
        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }

        public Account GetAccountDetails(int accountId)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == accountId);
        }

        public decimal GetAccountsBalance(int accountId)
        {
            return GetAccountDetails(accountId).Balance;
        }

        public void UpdateAccount(int accountId, Account account)
        {
            _context.Update(GetAccountDetails(accountId));
            SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

