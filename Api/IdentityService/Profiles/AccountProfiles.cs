using IdentityService.Dtos;
using IdentityService.Models;
using AutoMapper;

namespace IdentityService.Profiles
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

