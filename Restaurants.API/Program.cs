using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Presistence;
using Restaurants.Infrastructure.Extentions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Restaurants.API.middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddle>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Host.UseSerilog((context, configuration) =>
configuration
.ReadFrom.Configuration(context.Configuration)
);
var app = builder.Build();

var scope= app.Services.CreateScope();
var seeder= scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.SeedAsync();
// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddle>();
app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
