using System.Text.Json;
using AccountManagementService.Dtos;
using AccountManagementService.Models;
using AccountManagementService.Service;
using AutoMapper;

namespace AccountManagementService.EventProcessing
{
	public class EventProcessor : IEventProcessor
	{
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
		{
            _scopeFactory = scopeFactory;
            _mapper = mapper;

        }

        public void ProcessEvent(string eventDetail)
        {
            var eventType = DetermineEvent(eventDetail);
            switch (eventType)
            {
                case EventType.AccountCredited:
                    updateAccount(eventDetail, TransactionType.Credit);
                    break;
                case EventType.AccountDebited:
                    updateAccount(eventDetail, TransactionType.Debit);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string eventDetail) {
            Console.WriteLine("--> Determining Event Type");

            var eventDto = JsonSerializer.Deserialize<EventDto>(eventDetail);

            switch (eventDto.Event) {
                case "account.credited":
                    Console.WriteLine("--> Account Credit detected");
                    return EventType.AccountCredited;
                    break;
                case "account.dedited":
                    Console.WriteLine("--> Account Dedit detected");
                    return EventType.AccountCredited;
                    break;
                default:
                    Console.WriteLine("Could not determine event type");
                    return EventType.Undetermined;
                    break;
            }
            

        }

        private void updateAccount(string eventDetail, TransactionType transactionType)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
                var eventDto = JsonSerializer.Deserialize<EventDto>(eventDetail);
                try
                {
                    var transaction = _mapper.Map<Transaction>(eventDto.Message);
                    accountService.UpdateAccount(transaction.AccountId, transactionType, transaction.Amount);
                }
                catch (Exception ex) { Console.WriteLine($"Could not debit/credit account - {ex}"); }

            }
        }
    }

    enum EventType
    {
        AccountDebited,
        AccountCredited,
        Undetermined
    }
}

