using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommand> logger, IMapper mapper, 
        IRestaurantsRepository restaurantRepo, IDishRepository dishesRepo) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("adding new dish");
            var restaurant = await restaurantRepo.GetByIdAsync(request.RestaurantId);
            var dish = mapper.Map<Dish>(request);
            var dishId = await dishesRepo.Create(dish);
            return dishId;
            
        }
    }
}
