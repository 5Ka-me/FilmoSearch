using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.IoC
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IActorFilmRepository, ActorFilmRepository>();

            return services;
        }
    }
}
