using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Application.ViewModels
{
    public class CarouselProductViewModel
    {
        public IList<Carousel>? Carousels { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
