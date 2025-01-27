using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Infrastructure.Database.Seeding
{
    internal class CarouselInit
    {
        public IList<Carousel> GetCarouselsIT3()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/carousel/carousel1.jpg",
                ImageAlt = "First slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/carousel2.jpg",
                ImageAlt = "Second slide"
            });

            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/carousel3.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }
    }
}
