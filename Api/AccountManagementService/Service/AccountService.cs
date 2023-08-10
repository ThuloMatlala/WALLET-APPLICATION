using AccountManagementService.Data;
using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AutoMapper;

namespace AccountManagementService.Service
{
	public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepo accountRepo, ITransactionRepo transactionRepo, IMapper mapper)
		{
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
            _mapper = mapper;

        }

        public AccountReadDto UpdateAccount(int accountId, TransactionType transactionType, decimal amount)
        {
            var account = _accountRepo.GetAccountDetails(accountId);
            if (account == null)
                return default;
            if (transactionType == TransactionType.Credit)
                account.Balance += amount;
            else
                account.Balance -= amount;
            _accountRepo.UpdateAccount(accountId, account);
            var transaction = new Transaction { AccountId = accountId, Date = DateTime.Now, Amount = account.Balance };
            _transactionRepo.CreateTransaction(transaction);
            _transactionRepo.SaveChanges();
            var accountdetails = _accountRepo.GetAccountDetails(accountId);
            var accountReadDto = _mapper.Map<AccountReadDto>(accountdetails);
            return accountReadDto;
        }
    }
}

