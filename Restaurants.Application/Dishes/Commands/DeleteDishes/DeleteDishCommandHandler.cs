using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishCommandHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IRestaurantsRepository restaurantRepo) : IRequestHandler<DeleteDishCommand, bool>
    {
        public async Task<bool> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning($"Deleting all the dishes for restaurant {request.RestaurantId}");
            var restaurant= await restaurantRepo.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) return false;
            restaurant.Dishes.Clear();
            await restaurantRepo.Save();
            return true;
        }
    }
}
