using System.Text;
using AccountManagementService.EventProcessing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AccountManagementService.AsyncDataServices
{
	public class MessageBusSubscriber : BackgroundService
    {
        private IConfiguration _configuration;
        private readonly IEventProcessor _eventProcessor;
        private IConnection _connection;
        private IModel _channel;
        private string _queuename;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
		{
            _configuration = configuration;
            _eventProcessor = eventProcessor;
            InitializeRabbitMq();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Long running task listening for events
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("--> Event received!");
                var body = ea.Body;
                var eventDetail = Encoding.UTF8.GetString(body.ToArray());
                _eventProcessor.ProcessEvent(eventDetail);
            };

            _channel.BasicConsume(queue: _queuename, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        private void InitializeRabbitMq()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "wallet_app", type: ExchangeType.Fanout);
                _queuename = _channel.QueueDeclare().QueueName;
                _channel.QueueBind(queue: _queuename, exchange: "wallet_app", routingKey: "");
                Console.WriteLine($"--> Listening on the Message Bus...");
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"-->Could not connect to Message Bus : {ex}");
            }

        }


        public override void Dispose()
        {
            Console.WriteLine("Message Bus Disposed");
            if (_connection.IsOpen)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("-->RabbitMQ connection shutdown");
        }

    }
}

