using IdentityService.Dtos;
using IdentityService.Models;
using IdentityService.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IdentityService.AsyncDataServices;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;
        //todo : Find a better place to put this
        private static string _accountCreatedEvent = "account.created";

        public AuthorizationController(IAuthService authService, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _authService = authService;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpPost("register", Name = "AccountRegistration")]
        public ActionResult<AccountReadDto> Register([FromBody] AccountCreateDto userAccountCreateDto)
        {
            var userAccountModel = _mapper.Map<Account>(userAccountCreateDto);
            var errorMessage = _authService.CreateUserAccount(userAccountModel);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var newUserAccount = _authService.GetUserAccountByUserName(userAccountModel.Username);
                var userAccountReadDto = _mapper.Map<AccountReadDto>(newUserAccount);
                _messageBusClient.PublishMessage(_accountCreatedEvent, new EventDto { Event = _accountCreatedEvent, Message = userAccountReadDto.AccountId });
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
                return Content(_authService.CreateToken(userAccountModel));
            }
            else
                return BadRequest(errorMessage);
        }
    }
}

