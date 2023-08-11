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
                case EventType.AccountCreated:
                    CreateAccount(eventDetail);
                    break;
                case EventType.AccountCredited:
                    UpdateAccount(eventDetail, TransactionType.Credit);
                    break;
                case EventType.AccountDebited:
                    UpdateAccount(eventDetail, TransactionType.Debit);
                    break;
                default:
                    break;
            }
        }

        private void CreateAccount(string eventDetail)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
                var eventDto = JsonSerializer.Deserialize<EventDto>(eventDetail);
                var accountId = JsonSerializer.Deserialize<EventDto>(eventDetail);
                try
                {
                    var account = Convert.ToString(eventDto.Message);
                    var accountCreateDto = new AccountCreateDto { UserAccountId = Int32.Parse(account) };
                    accountService.CreateAccount(accountCreateDto);
                }
                catch (Exception ex) { Console.WriteLine($"Could not debit/credit account - {ex}"); }

            }
        }

        private EventType DetermineEvent(string eventDetail) {
            Console.WriteLine("--> Determining Event Type");

            var eventDto = JsonSerializer.Deserialize<EventDto>(eventDetail);

            switch (eventDto.Event)
            {
                case "account.created":
                    Console.WriteLine("--> Account Creation detected");
                    return EventType.AccountCreated;
                case "account.credited":
                    Console.WriteLine("--> Account Credit detected");
                    return EventType.AccountCredited;
                case "account.debited":
                    Console.WriteLine("--> Account Dedit detected");
                    return EventType.AccountCredited;
                default:
                    Console.WriteLine("Could not determine event type");
                    return EventType.Undetermined;
            }
            

        }

        private void UpdateAccount(string eventDetail, TransactionType transactionType)
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
        Undetermined,
        AccountCreated
    }
}

