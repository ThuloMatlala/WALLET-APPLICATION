namespace Gateway.AsyncDataServices
{
	public interface IMessageBusClient
    {
        void PublishMessage(string eventTopic, object message);
    }
}

