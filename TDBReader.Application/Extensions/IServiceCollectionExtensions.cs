using Microsoft.Extensions.DependencyInjection;
using TDBReader.Application.Delegates;

namespace TDBReader.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<KafkaMessageSender>();
        }

    }
}
