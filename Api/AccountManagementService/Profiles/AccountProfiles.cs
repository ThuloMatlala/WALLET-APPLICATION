using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AutoMapper;

namespace AccountManagementService.Profiles
{
	public class AccountProfiles : Profile
    {
		public AccountProfiles()
        {
            // Source -> Target
            // DB -> extrenal source
            CreateMap<Account, AccountReadDto>();
            CreateMap<Transaction, TransactionReadDto>();
            // External source -> DB
            CreateMap<AccountCreateDto, Account>();
            CreateMap<TransactionCreateDto, Transaction>();
        }
	}
}

