using System;
namespace AccountManagementService.EventProcessing
{
	public class EventProcessor : IEventProcessor
	{
		public EventProcessor()
		{
		}

        public void Process(string message)
        {
            throw new NotImplementedException();
        }

        enum EventType
        {

        }
    }
}

