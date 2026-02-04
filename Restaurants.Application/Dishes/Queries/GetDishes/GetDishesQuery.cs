using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.Application.Dishes.Queries.GetDishes
{
    public class GetDishesQuery(int RestaurantId):IRequest<IEnumerable<DishDto>>
    {
        
        public int RestaurantId { get; } = RestaurantId;
    }
}
