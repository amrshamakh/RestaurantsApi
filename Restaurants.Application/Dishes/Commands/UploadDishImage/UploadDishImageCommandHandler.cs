using MediatR;
using Restaurants.Application.Common.Interfaces;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.UploadDishImage
{
    public class UploadDishImageCommandHandler (IRestaurantsRepository ResturantRepository,IFileStorage storage): IRequestHandler<UploadDishImageCommand, string>
    {
        public async Task<string> Handle(UploadDishImageCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await ResturantRepository.GetByIdAsync(request.RestaurantId);
            if(restaurant == null) { throw new NotFoundException(typeof(Restaurant).ToString(),request.RestaurantId.ToString()); }
            var dish=restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if(dish == null)
            {
                throw new NotFoundException(typeof(Dish).ToString(),request.DishId.ToString());
            }

            var url= await storage.SaveFileAsync(request.Stream, request.FileName, request.ContentType);
            dish.ImageUrl = url; 
            await ResturantRepository.Save(); 
            return url;
        }
    }
}
