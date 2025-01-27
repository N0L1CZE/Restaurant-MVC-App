using UTB.Restaurant.Application.ViewModels;

namespace UTB.Restaurant.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselProductViewModel GetIndexViewModel();
    }
}
