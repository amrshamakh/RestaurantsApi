using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishById;
using Restaurants.Application.Dishes.Queries.GetDishes;
//using Restaurants.Application.Restaurants.Dtos;
//using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{DishId}")]
        public async Task<ActionResult<DishDto>> GetById([FromRoute]int restaurantId ,[FromRoute]int DishId)
        {
            // Implementation for getting a restaurant by ID
            var Dish = await mediator.Send(new GetDishByIdQuery(restaurantId,DishId));// Placeholder
            if (Dish == null) return NotFound();
            return Ok(Dish);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId,CreateDishCommand command)
        {
            if (ModelState.IsValid)
            {
                command.RestaurantId= restaurantId;
                int id =await mediator.Send(command);
                //return CreatedAtAction(nameof(GetById),new {id},command);
                return Created();
            }
            else return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute]int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesQuery(restaurantId));
            return Ok(dishes);
        }
    }
}
