using UTB.Restaurant.Application.Abstraction;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Database;

namespace UTB.Restaurant.Application.Implementation
{
    public class CarouselAppService(RestaurantDbContext restaurantDbContext) : ICarouselAppService
    {

        public IList<Carousel> Select()
        {
            return restaurantDbContext.Carousels.ToList();
        }
    }
}
