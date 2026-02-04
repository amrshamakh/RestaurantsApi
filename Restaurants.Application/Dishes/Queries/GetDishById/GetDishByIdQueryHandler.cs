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

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
    public class GetDishByIdQueryHandler(ILogger<GetDishByIdQuery> logger, IMapper mapper,
        IRestaurantsRepository restaurantRepo) : IRequestHandler<GetDishByIdQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("getting the dish {DishId} from the restaurant {restId}", request.DishId, request.RestaurantId);
            var Restaurant = await restaurantRepo.GetByIdAsync(request.RestaurantId);
            var dish=Restaurant.Dishes.FirstOrDefault(d=>d.Id==request.DishId);
            var result = mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
