using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;


namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Add application services here
            var ApplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(ApplicationAssembly));
            services.AddAutoMapper(cfg => { },ApplicationAssembly);
            services.AddValidatorsFromAssembly(ApplicationAssembly).AddFluentValidationAutoValidation();
        }
    }
}
