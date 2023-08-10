using AuthorizationService.Models;

namespace AuthorizationService.Data
{
	public interface IAuthorizationRepo
    {
        void CreateUserAccount(UserAccount userAccount);
        bool SaveChanges();
        UserAccount GetUserAccountById(int accountId);
        UserAccount GetUserAccountByUserName(string userName);
    }
}

