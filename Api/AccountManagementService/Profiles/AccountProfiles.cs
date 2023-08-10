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
            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountCreateDto, Account>();
        }
	}
}

