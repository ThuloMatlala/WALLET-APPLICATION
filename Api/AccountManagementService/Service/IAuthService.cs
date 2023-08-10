using AccountManagementService.Dtos;
using AccountManagementService.Models;

namespace AccountManagementService.Services
{
    public interface IAuthService
    {
        string CreateToken(AccountReadDto userAccountReadDto);
        string CreateUserAccount(Account userAccount);
        Account GetUserAccountById(int accountId);
        Account GetUserAccountByUserName(string userName);
        string? Login(Account userAccountModel);
    }
}

