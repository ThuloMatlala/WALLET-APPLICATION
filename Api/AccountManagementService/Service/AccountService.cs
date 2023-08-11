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

        public void CreateAccount(AccountCreateDto accountCreateDto)
        {
            var account = _mapper.Map<Account>(accountCreateDto);
            _accountRepo.CreateAccount(account);
            _accountRepo.SaveChanges();
        }

        public AccountReadDto UpdateAccount(int userAccountId, TransactionType transactionType, decimal amount)
        {
            var account = _accountRepo.GetAccountDetailsByUserAccount(userAccountId);
            if (account == null)
                return default;
            if (transactionType == TransactionType.Credit)
                account.Balance += amount;
            else
                account.Balance -= amount;
            
            _accountRepo.UpdateAccount(userAccountId, account);
            var transaction = new Transaction { AccountId = userAccountId, Date = DateTime.Now, Amount = account.Balance };
            _transactionRepo.CreateTransaction(transaction);
            _transactionRepo.SaveChanges();
            var accountdetails = _accountRepo.GetAccountDetailsByUserAccount(userAccountId);
            var accountReadDto = _mapper.Map<AccountReadDto>(accountdetails);
            return accountReadDto;
        }
    }
}

