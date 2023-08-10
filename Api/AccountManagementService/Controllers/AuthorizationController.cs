using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AccountManagementService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthorizationController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register", Name = "AccountRegistration")]
        public ActionResult<AccountReadDto> Register([FromBody] AccountCreateDto userAccountCreateDto)
        {
            var userAccountModel = _mapper.Map<Account>(userAccountCreateDto);
            var errorMessage = _authService.CreateUserAccount(userAccountModel);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var userAccountReadDto = _mapper.Map<AccountReadDto>(userAccountModel);
                return CreatedAtRoute("AccountRegistration", userAccountReadDto);
            }
            else
                return BadRequest(errorMessage);
        }

        [HttpPost("login", Name = "Login")]
        public ActionResult<AccountReadDto> Login([FromBody] AccountCreateDto userAccountCreateDto)
        {
            var userAccountModel = _mapper.Map<Account>(userAccountCreateDto);
            var errorMessage = _authService.Login(userAccountModel);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var userAccountReadDto = _mapper.Map<AccountReadDto>(userAccountModel);
                return Content(_authService.CreateToken(userAccountReadDto));
            }
            else
                return BadRequest(errorMessage);
        }
    }
}

