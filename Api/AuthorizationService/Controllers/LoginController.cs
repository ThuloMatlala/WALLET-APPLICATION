using AuthorizationService.Dtos;
using AuthorizationService.Models;
using AuthorizationService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/accounts/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }


        [HttpPost(Name = "Login")]
        public ActionResult<UserAccountReadDto> Login([FromBody] UserAccountCreateDto userAccountCreateDto)
        {
            var userAccountModel = _mapper.Map<UserAccount>(userAccountCreateDto);
            var errorMessage = _authService.Login(userAccountModel);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var userAccountReadDto = _mapper.Map<UserAccountReadDto>(userAccountModel);
                return Content(_authService.CreateToken(userAccountReadDto));
            }
            else
                return BadRequest(errorMessage);
        }
    }
}

