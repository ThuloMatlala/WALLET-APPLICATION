using AuthorizationService.Models;

namespace AuthorizationService.Services
{
    public interface IAuthService
    {
        void CreateUserAccount(UserAccount userAccount);
    }
}

