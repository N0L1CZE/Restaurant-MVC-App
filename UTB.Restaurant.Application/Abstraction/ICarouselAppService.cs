using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Application.Abstraction
{
    public interface ICarouselAppService
    {
        IList<Carousel> Select();
    }
}
