using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TransportScales.Core.Configuration;
using TransportScales.Data.Configuration;
using TransportScales.Test.Infrostrucure;

namespace TransportScales.Test
{
    public class Startup : IDependencyRegistrator
    {
        public IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddLogging(logging => logging.AddConsole());
            services.AddInMemoryDbContext();
            services.MakeRepositoryDependencies();
            services.MakeServiceDependencies();
            services.AddAutoMapper(typeof(MapperConfiguration));
            services.AddMemoryCache();

            return services.BuildServiceProvider();
        }
    }
}
