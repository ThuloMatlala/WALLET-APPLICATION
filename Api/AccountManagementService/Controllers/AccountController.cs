using AccountManagementService.Data;
using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepo accountRepo, ITransactionRepo transactionRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
            _mapper = mapper;
        }

        [HttpGet("{accountId}/transactions", Name = "GetTransactionsHistory")]
        public async Task<ActionResult<IEnumerable<Transaction>>> TransactionsHistory([FromRoute] int accountId)
        {
            var result = await _transactionRepo.GetAllTransactionsByAccountId(accountId);
            if (result == null)
                return BadRequest("Account not found");
            return Ok(result);

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
        public string CreditAccount([FromRoute] int accountId, TransactionCreateDto transactionCreateDto)
        {
            return $"Credit {transactionCreateDto.Amount} from account {accountId}";

        }

        [HttpPut("{accountId}/debit", Name = "DebitAccount")]
        public string DebitAccount([FromRoute] int accountId, TransactionCreateDto transactionCreateDto)
        {
            return $"Debit {transactionCreateDto.Amount} from account {accountId}";

        }
    }
}

