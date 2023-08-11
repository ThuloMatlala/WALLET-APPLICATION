using AccountManagementService.Dtos;
using AccountManagementService.Models;

namespace AccountManagementService.Service
{
	public interface IAccountService
    {
        AccountReadDto UpdateAccount(int accountId, TransactionType transactionType, decimal amount);
        void CreateAccount(AccountCreateDto accountId);
    }
}

