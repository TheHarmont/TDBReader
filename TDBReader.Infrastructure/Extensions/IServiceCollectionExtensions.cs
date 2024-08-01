using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDBReader.Domain.Interfaces;
using TDBReader.Infrastructure.Services;

namespace TDBReader.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
        }

        private static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var kafkaConfig = configuration.GetSection("Kafka");
            var bootstrapServers = kafkaConfig["BootstrapServers"];
            var topic = kafkaConfig["Topic"];

            services.
                AddSingleton<ITimerService,TimerService>().
                AddTransient<ITelemedService, TelemedService>().
                AddSingleton<IKafkaProducerService, KafkaProducerService>(sp => new KafkaProducerService(bootstrapServers, topic));
        }
    }
}
