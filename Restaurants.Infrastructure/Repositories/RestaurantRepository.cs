using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Presistence;
using System.Runtime.InteropServices;


namespace Restaurants.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantsRepository
    {
        private readonly RestaurantsDbContext context;

        public RestaurantRepository(RestaurantsDbContext context)
        {
            this.context = context;
        }



        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var Restaurants = await context.Restaurants.ToListAsync();
            return Restaurants;
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            var restaurant = await context.Restaurants.Include(r=>r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public async Task<int> AddRestaurantAsync(Restaurant restaurant)
        {
          
                await context.Restaurants.AddAsync(restaurant);
                await context.SaveChangesAsync();
                return restaurant.Id;
            
         }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if(restaurant == null)
            {
                return false;
            }else
            {
                context.Restaurants.Remove(restaurant);
                await context.SaveChangesAsync();
                return true;
            }

        }
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
