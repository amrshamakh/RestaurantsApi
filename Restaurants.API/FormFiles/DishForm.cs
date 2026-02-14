namespace Restaurants.API.FormFiles
{
    public class DishForm
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; }= default!;
        public string PhoneNumber { get; set; } = default!;
        public string Specialization { get; set; } = default!;

        public IFormFile VerificationDocument { get; set; } = default!;
    }
}
