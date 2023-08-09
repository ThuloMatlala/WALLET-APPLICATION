using AccountManagementService.Models;
using AutoMapper;
using AuthorizationService.Dtos;

namespace AuthorizationService.Profiles
{
	public class UserAccountProfiles : Profile
    {
		public UserAccountProfiles()
        {
            // Source -> Target
            // DB -> extrenal source
            CreateMap<UserAccount, UserAccountReadDto>();
            // External source -> DB
            CreateMap<UserAccountCreateDto, UserAccount>();
        }
	}
}

