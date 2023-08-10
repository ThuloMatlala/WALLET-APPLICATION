using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AutoMapper;

namespace AccountManagementService.Profiles
{
	public class TransactionProfile : Profile
	{
		public TransactionProfile()
        {
            // Source -> Target
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionCreateDto, Transaction>();
        }
	}
}

