
using Microsoft.AspNetCore.Mvc;
using UserAccountManagementService.Dtos;

namespace UserAccountManagementService.Controllers
{
    [ApiController]
    [Route("accounts/[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "UserAccountRegistration")]
        public IEnumerable<UserAccountReadDto> RegisterUserAccount(UserAccountCreateDto userAccountCreateDto)
        {

        }

    }
}

