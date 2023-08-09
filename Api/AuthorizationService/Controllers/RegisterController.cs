
using Microsoft.AspNetCore.Mvc;
using AuthorizationService.Dtos;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/accounts/[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        //[HttpPost(Name = "UserAccountRegistration")]
        //public IEnumerable<UserAccountReadDto> RegisterUserAccount(UserAccountCreateDto userAccountCreateDto)
        //{
        //    return new UserAccountReadDto();
        //}



        [HttpPost(Name = "AccountRegistration")]
        public string RegisterAccount(UserAccountCreateDto userAccountCreateDto)
        {
            return "Cheese";

        }
    }
}
