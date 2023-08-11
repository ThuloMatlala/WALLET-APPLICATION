using Gateway.Dtos;
using Gateway.Models;
using AutoMapper;

namespace Gateway.Profiles
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

