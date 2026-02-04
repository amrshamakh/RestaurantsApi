using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator:AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(d => d.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative number.");
            RuleFor(d => d.kiloCalories).GreaterThanOrEqualTo(0).WithMessage("kalories must be a non-negative number.");
        }
    }
}
