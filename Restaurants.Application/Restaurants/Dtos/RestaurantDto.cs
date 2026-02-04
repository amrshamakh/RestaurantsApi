
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [MaxLength(100),MinLength(3)]
        public string Name { get; set; } = default!;
        public string Descrition { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        [EmailAddress(ErrorMessage ="Please provide a valid email address")]
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        [RegularExpression(@"^\d{2}-\d{3}$",ErrorMessage ="Please provide a valid postal code (XX-XXX).")]
        public string? Postal { get; set; }
        public List<DishDto> Dishes { get; set; } = new();


    }
}
