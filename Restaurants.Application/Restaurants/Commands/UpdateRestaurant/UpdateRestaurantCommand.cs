
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand:IRequest<bool>
    {

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Descrition { get; set; } = default!;

        public bool HasDelivery { get; set; }
    }

}
