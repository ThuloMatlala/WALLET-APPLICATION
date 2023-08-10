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
    //[Authorize]
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

        [HttpGet("{accountId}/transactions", Name = "GetTransactionsHistory")]
        public async Task<ActionResult<IEnumerable<TransactionReadDto>>> TransactionsHistory([FromRoute] int accountId)
        {
            var transactions = await _transactionRepo.GetAllTransactionsByAccountId(accountId);
            if (transactions == null)
                return BadRequest("Account not found");
            return Ok(transactions);

        }

        [HttpGet("{accountId}/balance", Name = "GetAccountBalance")]
        public async Task<ActionResult<decimal>> GetAccountBalance([FromRoute] int accountId)
        {
            var result = await _accountRepo.GetAccountsBalance(accountId);
            if(result == 0)
                return BadRequest("Account not found");
            return Ok(result);

        }

        [HttpPut("{accountId}/credit", Name = "CreditAccount")]
        public ActionResult<AccountReadDto> CreditAccount([FromRoute] int accountId, TransactionCreateDto transactionCreateDto)
        {
            var account = _accountService.UpdateAccount(accountId, TransactionType.Credit, transactionCreateDto.Amount);
            if (account == null)
                return BadRequest("Account not found");
            return Ok(account);
        }

        [HttpPut("{accountId}/debit", Name = "DebitAccount")]
        public ActionResult<AccountReadDto> DebitAccount([FromRoute] int accountId, TransactionCreateDto transactionCreateDto)
        {
            var account = _accountService.UpdateAccount(accountId, TransactionType.Debit, transactionCreateDto.Amount);
            if (account == null)
                return BadRequest("Account not found");
            return Ok(account);
        }
    }
}

