using AccountManagementService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        [HttpGet("{accountId}/transactions", Name = "GetTransactionsHistory")]
        public string TransactionsHistory([FromRoute] int accountId)
        {
            return $"Get transcactions for : {accountId}";

        }

        [HttpGet("{accountId}/balance", Name = "GetAccountBalance")]
        public string GetAccountBalance([FromRoute] int accountId)
        {
            return $"Get balance for : {accountId}";

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

