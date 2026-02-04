using MediatR;
using Restaurants.Application.Dishes.Dtos;


namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    //represent the data needed to create new restaurant
    public class CreateRestaurantCommand:IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Descrition { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
     
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        public string? Postal { get; set; }
        public List<DishDto> Dishes { get; set; } = new();


    }
}
