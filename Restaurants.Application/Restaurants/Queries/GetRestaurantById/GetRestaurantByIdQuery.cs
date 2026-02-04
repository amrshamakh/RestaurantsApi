using MediatR;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery:IRequest<RestaurantDto>
    {
        public GetRestaurantByIdQuery(int id)
        {
         this.id = id;
        }
        public int id { get; set; }
    }
}
