using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishes
{
    public class GetDishesQueryHandler(ILogger<GetDishesQuery> logger, IMapper mapper,
        IRestaurantsRepository restaurantRepo) : IRequestHandler<GetDishesQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("retrieving dishes for restaurant with id :{RestaurantId}", request.RestaurantId);
            var restaurant = await restaurantRepo.GetByIdAsync(request.RestaurantId);
            var dishes=mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
            return dishes;
        }
    }
}
