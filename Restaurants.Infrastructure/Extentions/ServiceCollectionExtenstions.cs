using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Common.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Presistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Infrastructure.Storage;


namespace Restaurants.Infrastructure.Extentions
{
    public static class ServiceCollectionExtenstions
    {
        public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<Presistence.RestaurantsDbContext>(options => options.UseSqlServer(config.GetConnectionString("default")));
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            // Add infrastructure services here
            services.AddScoped<IRestaurantsRepository, RestaurantRepository>();
            services.AddScoped<IDishRepository, DishesRepository>();
            services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RestaurantsDbContext>();
            services.AddScoped<IFileStorage, FileStorage>();
        }
    }
}
