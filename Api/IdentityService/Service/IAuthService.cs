using IdentityService.Dtos;
using IdentityService.Models;

namespace IdentityService.Services
{
    public interface IAuthService
    {
        string CreateToken(Account userAccountReadDto);
        string CreateUserAccount(Account userAccount);
        Account GetUserAccountById(int accountId);
        Account GetUserAccountByUserName(string userName);
        string? Login(Account userAccountModel);
    }
}

