using System.Security.Cryptography;
using System.Text;
using AuthorizationService.Data;
using AuthorizationService.Models;
using Microsoft.Identity.Client;

namespace AuthorizationService.Services
{
	public class AuthService : IAuthService
	{
        private readonly IAuthorizationRepo _authorizationRepo;

        public AuthService(IAuthorizationRepo authorizationRepo)
		{
            _authorizationRepo = authorizationRepo;

        }

        public string CreateUserAccount(UserAccount userAccount)
        {
            if (string.IsNullOrEmpty(userAccount.Username))
                return "Please enter a valid UserName";
            if (UsernameExists(userAccount.Username))
                return "Oops. The username you have chosen already exists";
            if (string.IsNullOrEmpty(userAccount.Password))
                return "Please enter a valid Password";
            userAccount.Password = HashPassword(userAccount.Password);
            _authorizationRepo.CreateUserAccount(userAccount);
            _authorizationRepo.SaveChanges();
            return string.Empty;
        }

        public UserAccount GetUserAccountById(int accountId)
        {
           return _authorizationRepo.GetUserAccountById(accountId);
        }

        public UserAccount GetUserAccountByUserName(string userName)
        {
            return _authorizationRepo.GetUserAccountByUserName(userName);
        }

        private bool UsernameExists(string username)
        {
            return _authorizationRepo.GetUserAccountByUserName(username) != null;
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}

