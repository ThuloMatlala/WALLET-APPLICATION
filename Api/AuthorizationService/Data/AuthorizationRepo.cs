using AuthorizationService.Models;

namespace AuthorizationService.Data
{
    public class AuthorizationRepo : IAuthorizationRepo
    {
        private AppDbContext _context;

        public AuthorizationRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUserAccount(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                throw new ArgumentNullException(nameof(userAccount));
            }

            _context.UserAccounts.Add(userAccount);
        }

        public UserAccount GetUserAccountById(int accountId)
        {
            return _context.UserAccounts.FirstOrDefault(x => x.Id == accountId);
        }

        public UserAccount GetUserAccountByUserName(string userName)
        {
            return _context.UserAccounts.FirstOrDefault(x => x.Username == userName);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

