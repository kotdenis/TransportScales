using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TransportScales.Core.Services.Implementation;
using TransportScales.Core.Services.Interfaces;
using TransportScales.Core.Validation;
using TransportScales.Dto.DtoModels;

namespace TransportScales.Core.Configuration
{
    public static class ServiceConfiguration
    {
        public static void MakeServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICacheManager, CacheManager>();
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<IJournalService, JournalService>();
            services.AddScoped<IValidator<TransportDto>, TransportValidator>();
        }
    }
}
