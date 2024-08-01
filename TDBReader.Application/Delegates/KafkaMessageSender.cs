using System.Text.Json;
using TDBReader.Domain.Entities;
using TDBReader.Domain.Interfaces;
using TDBReader.Domain.Interfaces.Repositories;

namespace TDBReader.Application.Delegates
{
    public class KafkaMessageSender
    {
        private readonly ITelemedService _telemedService;
        private readonly IKafkaProducerService _kafkaProducerService;

        public KafkaMessageSender(ITelemedService telemedService, IKafkaProducerService kafkaProducerService)
        {
            _telemedService = telemedService;
            _kafkaProducerService = kafkaProducerService;
        }

        public async Task OnTimerElapsedAsync(object? sender, EventArgs e)
        {
            var data = await _telemedService.GetActualTelemedNotice();
            foreach (var item in data)
            {
                await _kafkaProducerService.SendMessageAsync(JsonSerializer.Serialize(item, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                }));
            }
        }
    }
}
