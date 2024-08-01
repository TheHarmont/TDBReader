using Microsoft.Extensions.Hosting;
using TDBReader.Application.Delegates;
using TDBReader.Domain.Interfaces;

namespace TDBReader.HostedServices
{
    public class DataToKafkaHosted : IHostedService, IDisposable
    {
        private readonly ITimerService _timerService;
        private readonly KafkaMessageSender _kafkaMessageSender;

        public DataToKafkaHosted(ITimerService timerService, KafkaMessageSender kafkaMessageSender)
        {
            _timerService = timerService;
            _kafkaMessageSender = kafkaMessageSender;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Подписываемся на собития таймера
            _timerService.Elapsed += async (sender, e) => await _kafkaMessageSender.OnTimerElapsedAsync(sender, e);
            _timerService.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timerService.Stop();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerService.Dispose();
        }
    }
}
