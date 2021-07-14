using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;

namespace DevMeetings.Services.Meetings.Infrastructure.MessageBus
{
    public class RabbitMqClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMqClient()
        {
            var factory = new ConnectionFactory {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection("meeting-service-producer");
        }

        public void Publish(object message, string routingKey, string exchange)
        {
            var channel = _connection.CreateModel();

            var settings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var payload = JsonConvert.SerializeObject(message, settings);

            var body = Encoding.UTF8.GetBytes(payload);

            channel.ExchangeDeclare(exchange, "topic", true);

            channel.BasicPublish(exchange, routingKey, null, body);
        }
    }
}