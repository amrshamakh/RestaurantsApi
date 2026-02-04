using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Entities.Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(int id);
        Task<int> AddRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
        Task Save();
    }
}
