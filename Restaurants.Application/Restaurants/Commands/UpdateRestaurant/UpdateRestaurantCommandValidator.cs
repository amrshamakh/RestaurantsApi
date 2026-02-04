using FluentValidation;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant 
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {

        public UpdateRestaurantCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Restaurant name is required.")
                .MaximumLength(100).WithMessage("Restaurant name must not exceed 100 characters.").MinimumLength(3).WithMessage("name must be at least 3 characters");
        }
    
    }
}
