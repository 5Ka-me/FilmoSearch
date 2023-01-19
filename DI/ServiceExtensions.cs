using DAL.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);

            return services;
        }

        public static IServiceCollection AddBusinesslogic(this IServiceCollection services)
        {
            BLL.IoC.ServiceExtensions.AddBusiness(services);

            return services;
        }
    }
}