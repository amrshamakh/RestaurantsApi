using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler(ILogger<GetAllRestaurantsQueryHandler> logger,  IRestaurantsRepository restaurantRepo) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deletting restaurant with ID: {Id}", request.Id);
            var isDeleted =await restaurantRepo.DeleteRestaurantAsync(request.Id);
            return isDeleted;
        }
    }
}
