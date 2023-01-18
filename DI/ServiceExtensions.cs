using BLL.IoC;
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
            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddValidators();
            services.AddServices();

            return services;
        }
    }
}