using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthorizationService.Data;
using AuthorizationService.Dtos;
using AuthorizationService.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationService.Services
{
	public class AuthService : IAuthService
	{
        private readonly IAuthorizationRepo _authorizationRepo;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthorizationRepo authorizationRepo, IConfiguration configuration)
		{
            _authorizationRepo = authorizationRepo;
            _configuration = configuration;

        }

        public string CreateUserAccount(UserAccount userAccount)
        {
            var errorMessage = CredentialsAreValid(userAccount);
            if (UsernameExists(userAccount.Username))
                return "Oops. The username you have chosen already exists";
            if (string.IsNullOrEmpty(errorMessage))
            {
                userAccount.Password = HashPassword(userAccount.Password);
                _authorizationRepo.CreateUserAccount(userAccount);
                _authorizationRepo.SaveChanges();
            }
            return errorMessage;
        }

        public string? Login(UserAccount credentials)
        {
            var errorMessage = CredentialsAreValid(credentials);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var userAccount = _authorizationRepo.GetUserAccountByUserName(credentials.Username);
                if (userAccount == null || userAccount.Password != HashPassword(credentials.Password))
                    return "Oops. The credentials you provided do not match any user on our system.";
            }
            return errorMessage;
        }

        public UserAccount GetUserAccountById(int accountId)
        {
           return _authorizationRepo.GetUserAccountById(accountId);
        }

        public UserAccount GetUserAccountByUserName(string userName)
        {
            return _authorizationRepo.GetUserAccountByUserName(userName);
        }

        public string CreateToken(UserAccountReadDto userAccount)
        {
            List<Claim> claims = new List<Claim>();
            {
                new Claim(ClaimTypes.Name, userAccount.Username);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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

        private string CredentialsAreValid(UserAccount userAccount)
        {
            if (string.IsNullOrEmpty(userAccount.Username))
                return "Please enter a valid UserName";
            if (string.IsNullOrEmpty(userAccount.Password))
                return "Please enter a valid Password";
            return string.Empty;
        }

    }
}

