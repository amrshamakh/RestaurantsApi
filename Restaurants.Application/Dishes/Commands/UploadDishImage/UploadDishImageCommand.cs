using MediatR;

namespace Restaurants.Application.Dishes.Commands.UploadDishImage
{
    public class UploadDishImageCommand: IRequest<string>
    {

        public UploadDishImageCommand(int dishId, int restaurantId, Stream stream,string filename,string contentType)
        {
            DishId = dishId;
            RestaurantId = restaurantId;
            this.Stream = stream;
            FileName = filename;
            ContentType = contentType;

        }

        public int RestaurantId { get; set; }
        public int DishId { get; set; }
        public Stream Stream { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public string ContentType { get; set; } = default!;

    }
}
