using System.Security.Cryptography;
using System.Text;
using AuthorizationService.Data;
using AuthorizationService.Models;

namespace AuthorizationService.Services
{
	public class AuthService : IAuthService
	{
        private readonly IAuthorizationRepo _authorizationRepo;

        public AuthService(IAuthorizationRepo authorizationRepo)
		{
            _authorizationRepo = authorizationRepo;

        }

        public void CreateUserAccount(UserAccount userAccount)
        {
            userAccount.Password = HashPassword(userAccount.Password);
            _authorizationRepo.CreateUserAccount(userAccount);
            _authorizationRepo.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}

