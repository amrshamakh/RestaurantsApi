using AutoMapper.Configuration.Conventions;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
    public class GetDishByIdQuery(int restaurantId, int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get; set; } = restaurantId;
        public int DishId { get; set; } = dishId;
    }
}
