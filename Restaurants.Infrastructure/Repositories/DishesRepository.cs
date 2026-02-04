using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    public class DishesRepository(RestaurantsDbContext context) : IDishRepository
    {
        public async Task<int> Create(Dish entity)
        {
            context.Dishes.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
