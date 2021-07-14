namespace DevMeetings.Services.Meetings.Infrastructure.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}