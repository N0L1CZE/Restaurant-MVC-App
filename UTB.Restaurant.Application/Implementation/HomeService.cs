using UTB.Restaurant.Application.Abstraction;
using UTB.Restaurant.Application.ViewModels;

namespace UTB.Restaurant.Application.Implementation
{
    public class HomeService(IProductAppService productAppService,
                           ICarouselAppService carouselAppService) : IHomeService
    {
        public CarouselProductViewModel GetIndexViewModel()
        {
            CarouselProductViewModel viewModel = new CarouselProductViewModel();
            viewModel.Products = productAppService.Select();
            viewModel.Carousels = carouselAppService.Select();
            return viewModel;
        }
    }
}
