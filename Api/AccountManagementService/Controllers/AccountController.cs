using AccountManagementService.Data;
using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AccountManagementService.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepo accountRepo, ITransactionRepo transactionRepo, IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;

            _mapper = mapper;
        }

        [HttpGet("{userAccountId}/transactions", Name = "GetTransactionsHistory")]
        public async Task<ActionResult<IEnumerable<TransactionReadDto>>> TransactionsHistory([FromRoute] int userAccountId)
        {
            var transactions = await _transactionRepo.GetAllTransactionsByAccountId(userAccountId);
            if (transactions == null)
                return BadRequest("Account not found");
            return Ok(transactions);

        }

        [HttpGet("{userAccountId}/balance", Name = "GetAccountBalance")]
        public async Task<ActionResult<decimal>> GetAccountBalance([FromRoute] int userAccountId)
        {
            var accountDetails = _accountRepo.GetAccountDetailsByUserAccount(userAccountId);
            if (accountDetails == null)
                return BadRequest("Account not found");
            var result = await _accountRepo.GetAccountsBalance(userAccountId);
            return Ok(result);

        }

        [HttpPut("{userAccountId}/credit", Name = "CreditAccount")]
        public ActionResult<AccountReadDto> CreditAccount([FromRoute] int userAccountId, TransactionCreateDto transactionCreateDto)
        {
            var account = _accountService.UpdateAccount(userAccountId, TransactionType.Credit, transactionCreateDto.Amount);
            if (account == null)
                return BadRequest("Account not found");
            return Ok(account);
        }

        [HttpPut("{userAccountId}/debit", Name = "DebitAccount")]
        public ActionResult<AccountReadDto> DebitAccount([FromRoute] int userAccountId, TransactionCreateDto transactionCreateDto)
        {
            var account = _accountService.UpdateAccount(userAccountId, TransactionType.Debit, transactionCreateDto.Amount);
            if (account == null)
                return BadRequest("Account not found");
            return Ok(account);
        }
    }
}

