namespace RabbitMQTutorial.MessageBroker
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
