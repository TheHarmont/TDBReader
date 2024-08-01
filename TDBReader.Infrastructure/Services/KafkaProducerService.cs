using Confluent.Kafka;
using System.Net.Http;
using System.Text;
using TDBReader.Domain.Interfaces;

namespace TDBReader.Infrastructure.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;

        public KafkaProducerService(string bootstrapServers, string topic)
        {
            // Способ отправки сообщений через producer
            _producer = new ProducerBuilder<Null, string>(new ProducerConfig { BootstrapServers = bootstrapServers}).Build();

            _topic = topic;
        }

        public async Task SendMessageAsync(string message)
        {
            // Отправка сообщения в Kafka
            await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
        }
    }
}
