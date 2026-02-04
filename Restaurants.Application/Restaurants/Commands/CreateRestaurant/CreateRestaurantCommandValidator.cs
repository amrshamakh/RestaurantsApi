
using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class UpdateRestaurantCommandValidator:AbstractValidator<CreateRestaurantCommand>
    {
        private static readonly List<string>  validCategories = new()
        {
            "Italian",
            "Chinese",
            "Mexican",
            "Indian",
            "French",
            "Japanese",
            "Mediterranean"
        };
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(r=>r.Name).NotEmpty().WithMessage("Restaurant name is required.")
                .MaximumLength(100).WithMessage("Restaurant name must not exceed 100 characters.").MinimumLength(3).WithMessage("name must be at least 3 characters");
            RuleFor(r=>r.ContactEmail).EmailAddress().When(r=>!string.IsNullOrEmpty(r.ContactEmail)).WithMessage("Please provide a valid email address");
            RuleFor(dto => dto.Postal).Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");
            RuleFor(r=>r.Category).Custom((value,context)=>
            {
                if(!validCategories.Contains(value))
                {
                    context.AddFailure($"Category '{value}' is not valid. Valid categories are: {string.Join(", ", validCategories)}");
                }
            });
        }
    }
}
