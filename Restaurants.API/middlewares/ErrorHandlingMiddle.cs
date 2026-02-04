
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
