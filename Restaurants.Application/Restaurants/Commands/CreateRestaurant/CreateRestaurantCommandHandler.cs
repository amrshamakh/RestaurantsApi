using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantRepo) : IRequestHandler<CreateRestaurantCommand, int>
    {

        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding a new restaurant");
            var restaurant = mapper.Map<Restaurant>(request);
            //return await restaurantRepo.AddRestaurantAsync(restaurant);

            int id = await restaurantRepo.AddRestaurantAsync(restaurant);
            return id;
        }


    }
}

