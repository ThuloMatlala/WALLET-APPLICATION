
using Microsoft.AspNetCore.Mvc;
using AuthorizationService.Dtos;
using AutoMapper;
using AuthorizationService.Models;
using AuthorizationService.Services;

namespace AuthorizationService.Controllers
{
    [ApiController]
    [Route("api/accounts/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RegisterController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost(Name = "AccountRegistration")]
        public ActionResult<UserAccountReadDto> RegisterAccount([FromBody]UserAccountCreateDto userAccountCreateDto)
        {
            var userAccountModel = _mapper.Map<UserAccount>(userAccountCreateDto);
            _authService.CreateUserAccount(userAccountModel);
            var userAccountReadDto = _mapper.Map<UserAccountReadDto>(userAccountModel);
            return CreatedAtRoute("AccountRegistration", userAccountReadDto);
        }
    }
}
