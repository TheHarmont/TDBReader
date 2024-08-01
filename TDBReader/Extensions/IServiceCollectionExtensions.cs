using TDBReader.HostedServices;
using TDBReader.Presistence.Extensions;
using TDBReader.Application.Extensions;
using TDBReader.Infrastructure.Extensions;

namespace TDBReader.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayer();
            services.AddInfrastructureLayer(configuration);
            services.AddPersistenceLayer(configuration);
            services.AddPresentationLayer();
        }

        private static void AddPresentationLayer(this IServiceCollection services)
        {
            services.AddHostedService<DataToKafkaHosted>();
        }
    }
}
