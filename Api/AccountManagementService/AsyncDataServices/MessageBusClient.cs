using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace AccountManagementService.AsyncDataServices
{
	public class MessageBusClient : IMessageBusClient
	{
        private IConfiguration _configuration;
        private IConnection _connection;
        private IModel _channel;

        public MessageBusClient(IConfiguration configuration)
		{
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "wallet_app", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
                Console.WriteLine("--> Connected to message bus");

            } catch (Exception ex) {
                Console.WriteLine($"-->Could not connect to Message Bus : {ex}");
            }
		}

        public void PublishMessage(string eventTopic, object message)
        {
            var messageJson = JsonSerializer.Serialize(message);
            if (_connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ connection open. Sending message");
                SendMessage(eventTopic, messageJson);
            }
            else
            {
                Console.WriteLine("--> RabbitMQ connection not open. Unable to send message");
            }
        }

        //Cleans up when our class shuts dounw
        public void Dispose() {
            Console.WriteLine("Message Bus Disposed");
            if (_connection.IsOpen) {
                _connection.Close();
                _connection.Dispose();
            }
        }

        private void SendMessage(string eventTopic, string message) {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "wallet_app", routingKey: eventTopic, basicProperties: null, body: body);
            Console.WriteLine($"--> Message sent : {message}");
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("-->RabbitMQ connection shutdown");
        }

    }
}

