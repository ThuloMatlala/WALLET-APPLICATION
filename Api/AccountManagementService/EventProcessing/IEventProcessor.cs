namespace AccountManagementService.EventProcessing
{
	public interface IEventProcessor
	{
		void Process(string message);
	}
}

