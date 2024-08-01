using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDBReader.Domain.Interfaces.Repositories;
using TDBReader.Presistence.Context;
using TDBReader.Presistence.Repositories;

namespace TDBReader.Presistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        private const string ConnectionStringName = "rmis-tmkup-db";

        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            services.AddDbContext<TelemedDBContext>(options =>
               options.UseNpgsql(connectionString));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.
                AddScoped<ITelemedRepository, TelemedRepository>();
        }
    }
}
