
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.middlewares
{
    public class ErrorHandlingMiddle(ILogger<ErrorHandlingMiddle> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
           catch(NotFoundException notFound)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(notFound.Message);
                logger.LogWarning(notFound.Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex,ex.Message);
                //response
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("something went wrong");

            }
        }
    }
}
