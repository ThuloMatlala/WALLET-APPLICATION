using AuthorizationService.Dtos;
using AuthorizationService.Models;

namespace AuthorizationService.Services
{
    public interface IAuthService
    {
        string CreateToken(UserAccountReadDto userAccountReadDto);
        string CreateUserAccount(UserAccount userAccount);
        UserAccount GetUserAccountById(int accountId);
        UserAccount GetUserAccountByUserName(string userName);
        string? Login(UserAccount userAccountModel);
    }
}

