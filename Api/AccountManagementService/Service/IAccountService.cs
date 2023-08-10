using AccountManagementService.Models;

namespace AccountManagementService.Service
{
	public interface IAccountService
    {
        Account UpdateAccount(int accountId, TransactionType transactionType, decimal amount);
    }
}

