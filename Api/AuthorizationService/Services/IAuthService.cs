using AuthorizationService.Models;

namespace AuthorizationService.Services
{
    public interface IAuthService
    {
        string CreateUserAccount(UserAccount userAccount);
        UserAccount GetUserAccountById(int accountId);
        UserAccount GetUserAccountByUserName(string userName);
        string? Login(UserAccount userAccountModel);
    }
}

