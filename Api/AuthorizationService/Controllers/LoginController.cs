using AuthorizationService.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/accounts/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        //[HttpPost(Name = "UserAccountRegistration")]
        //public IEnumerable<UserAccountReadDto> RegisterUserAccount(UserAccountCreateDto userAccountCreateDto)
        //{
        //    return new UserAccountReadDto();
        //}



        [HttpPost(Name = "AccountLogin")]
        public string AccountLogin(UserAccountCreateDto userAccountCreateDto)
        {
            return "Cheese";

        }
    }
}

