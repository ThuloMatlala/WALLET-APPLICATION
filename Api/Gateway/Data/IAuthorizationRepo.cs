using Gateway.Models;

namespace Gateway.Data
{
	public interface IAuthorizationRepo
    {
        void CreateUserAccount(Account userAccount);
        bool SaveChanges();
        Account GetUserAccountById(int accountId);
        Account GetUserAccountByUserName(string userName);
    }
}

