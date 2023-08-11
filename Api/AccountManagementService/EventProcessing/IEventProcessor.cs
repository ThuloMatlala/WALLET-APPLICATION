namespace AccountManagementService.EventProcessing
{
	public interface IEventProcessor
	{
		void ProcessEvent(string message);
	}
}

