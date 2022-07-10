using Microsoft.Extensions.DependencyInjection;
using TransportScales.Data.Repositries.Implementation;
using TransportScales.Data.Repositries.Interfaces;

namespace TransportScales.Data.Configuration
{
    public static class RepositoryDependencies
    {
        public static void MakeRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<ITransportQuantityRepository, TransportQuantityRepository>();
        }
























    }
}
