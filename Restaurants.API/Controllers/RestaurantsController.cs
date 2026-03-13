using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RestaurantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAsync()
        {
            Console.WriteLine($"------------{User.Identity?.Name}--------------------");
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById(int id)
        {
            // Implementation for getting a restaurant by ID
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));// Placeholder
            if (restaurant == null) return NotFound();
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            if (ModelState.IsValid)
            {
                int? id =await mediator.Send(command);
              
                 return CreatedAtAction(nameof(GetById), new { id }, command);
                
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
        {
            var isDeleted= await mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdataRestaurant([FromRoute]int id ,[FromBody]UpdateRestaurantCommand command)
        {
            command.Id = id;
            var IsUpdated = await mediator.Send(command);
            if (IsUpdated)
                return NoContent();
            else return NotFound();
;
        }
    }
}
