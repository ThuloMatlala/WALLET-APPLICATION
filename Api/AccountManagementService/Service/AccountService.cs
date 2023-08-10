using AccountManagementService.Data;
using AccountManagementService.Models;

namespace AccountManagementService.Service
{
	public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;

        public AccountService(IAccountRepo accountRepo, ITransactionRepo transactionRepo)
		{
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;

        }

        public Account UpdateAccount(int accountId, TransactionType transactionType, decimal amount)
        {
            var account = _accountRepo.GetAccountDetails(accountId);
            if (transactionType == TransactionType.Credit)
                account.Balance += amount;
            else
                account.Balance -= amount;
            _accountRepo.UpdateAccount(accountId, account);
            var transaction = new Transaction { AccountId = accountId, Account = account, Date = DateTime.Now };
            _transactionRepo.CreateTransaction(transaction);
            return _accountRepo.GetAccountDetails(accountId);
        }
    }
}

