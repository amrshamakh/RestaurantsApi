using AutoMapper.Configuration.Conventions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishCommand:IRequest<bool>
    {
        public DeleteDishCommand(int id)
        {
            RestaurantId = id;
        }
        public int RestaurantId { get; set; }
    }
}
