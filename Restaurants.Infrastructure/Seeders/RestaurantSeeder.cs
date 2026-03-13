using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Presistence;

namespace Restaurants.Infrastructure.Seeders
{

    public class RestaurantSeeder : IRestaurantSeeder
    {
        private readonly RestaurantsDbContext context;

        public RestaurantSeeder(RestaurantsDbContext context)
        {
            this.context = context;
        }
        public async Task SeedAsync()
        {
            if(await context.Database.CanConnectAsync())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    context.Restaurants.AddRange(restaurants);
                    await context.SaveChangesAsync();
                }
                if (!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = [
                new(UserRoles.User){
                    NormalizedName = UserRoles.User.ToUpper()
                },
                new(UserRoles.Owner){
                    NormalizedName = UserRoles.Owner.ToUpper()
                },
                new(UserRoles.Admin) { NormalizedName = UserRoles.Admin.ToUpper() }
                ];
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            return new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "The Gourmet Kitchen",
                    Descrition = "A fine dining experience with international cuisine.",
                    Category = "Fine Dining",
                    HasDelivery = false,
                    ContactEmail = "eng952@gmail.com",
                    ContactNumber = "+201228517600",
                    Address = new Address
                    {
                        City = "Cairo",
                        Street = "Tahrir Street 12",
                        Postal = "11511"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Steak Au Poivre", Price = 350 ,Description="Steak Au Poivre" },
                        new Dish { Name = "Lobster Bisque", Price = 280 ,Description = "Lobster Bisque"}
                    }
                },

                new Restaurant
                {
                    Name = "Pizza Roma",
                    Descrition = "Authentic Italian pizza made with wood-fired ovens.",
                    Category = "Italian",
                    HasDelivery = true,
                    ContactEmail = "info@pizzaroma.com",
                    ContactNumber = "+201006789456",
                    Address = new Address
                    {
                        City = "Giza",
                        Street = "Pyramids Road 88",
                        Postal = "12655"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Margherita", Price = 120 , Description = "Margherita"},
                        new Dish { Name = "Pepperoni", Price = 150 ,Description = "Pepperoni" }
                    }
                },

                new Restaurant
                {
                    Name = "Sushi World",
                    Descrition = "Fresh sushi and Japanese dishes prepared daily.",
                    Category = "Japanese",
                    HasDelivery = true,
                    ContactEmail = "hello@sushiworld.com",
                    ContactNumber = "+201234009876",
                    Address = new Address
                    {
                        City = "Alexandria",
                        Street = "Corniche Road 45",
                        Postal = "21532"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "California Roll", Price = 90 , Description = "California Roll"},
                        new Dish { Name = "Tempura Shrimp", Price = 140 , Description = "Tempura Shrimp"}
                    }
                },

                new Restaurant
                {
                    Name = "El Masry Grill",
                    Descrition = "Traditional Egyptian grilled dishes.",
                    Category = "Egyptian",
                    HasDelivery = true,
                    ContactEmail = "eissaamr308@gmail.com",
                    ContactNumber = "+201275869550",
                    Address = new Address
                    {
                        City = "Cairo",
                        Street = "Nasr City 10",
                        Postal = "11765"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish { Name = "Kofta", Price = 80 , Description = "Kofta"},
                        new Dish { Name = "Grilled Chicken", Price = 130 ,Description="Grilled Chicken"}
                    }
                }
            };
        }
    }
}