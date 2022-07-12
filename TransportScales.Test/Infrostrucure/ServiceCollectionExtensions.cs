using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransportScales.Data;

namespace TransportScales.Test.Infrostrucure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<TransportDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
            return services;
        }
    }
}
