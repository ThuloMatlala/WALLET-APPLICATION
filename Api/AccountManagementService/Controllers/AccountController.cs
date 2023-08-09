using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet("{id}/transactions", Name = "GetTransactionsHistory")]
        public int TransactionsHistory([FromRoute] int id)
        {
            return id;

        }

        [HttpGet("{id}/balance", Name = "GetAccountBalance")]
        public int GetAccountBalance([FromRoute] int id)
        {
            return id;

        }

        [HttpPut("{id}/credit", Name = "CrebitAccount")]
        public decimal CrebitAccount([FromRoute] int id, decimal amount)
        {
            return amount;

        }

        [HttpPut("{id}/debit", Name = "DebitAccount")]
        public decimal DebitAccount([FromRoute] int id, decimal amount)
        {
            return amount;

        }
    }
}

