using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IRestaurantsRepository restaurantRepo) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("updating for restaurant: {Name}", request.Name);
            var restaurant = await restaurantRepo.GetByIdAsync(request.Id);
            if (restaurant is null)
            {
                return false;
            }
            restaurant.Name = request.Name;
            restaurant.Descrition = request.Descrition;
            restaurant.HasDelivery = request.HasDelivery;
            await restaurantRepo.Save();
            return true;
        }
    }
}
