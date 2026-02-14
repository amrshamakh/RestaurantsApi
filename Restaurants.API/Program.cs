using Restaurants.API.Extensions;
using Restaurants.API.middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Addpresentation();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

var scope= app.Services.CreateScope();
var seeder= scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.SeedAsync();
// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddle>();
app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.MapGroup("api/identity")
    .WithTags("Identity")
.MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
