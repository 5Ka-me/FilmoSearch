using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using BLL.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BLL.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddUtility(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ActorModel>, ActorValidator>();
            services.AddScoped<IValidator<FilmModel>, FilmValidator>();
            services.AddScoped<IValidator<ReviewModel>, ReviewValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IActorFilmService, ActorFilmService>();

            return services;
        }
    }
}
