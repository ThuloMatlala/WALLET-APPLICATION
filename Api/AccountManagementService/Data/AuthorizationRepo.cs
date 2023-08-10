using AccountManagementService.Models;

namespace AccountManagementService.Data
{
    public class AuthorizationRepo : IAuthorizationRepo
    {
        private AppDbContext _context;

        public AuthorizationRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUserAccount(Account userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentNullException(nameof(userAccount));
            }

            _context.Accounts.Add(userAccount);
        }

        public Account GetUserAccountById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == accountId);
        }

        public Account GetUserAccountByUserName(string userName)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == userName);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

