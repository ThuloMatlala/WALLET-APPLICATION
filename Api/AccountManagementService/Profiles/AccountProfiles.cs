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
            // External source -> DB
            CreateMap<AccountCreateDto, Account>();
        }
	}
}

