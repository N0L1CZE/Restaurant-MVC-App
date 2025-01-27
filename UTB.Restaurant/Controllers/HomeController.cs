using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UTB.Restaurant.Application.Abstraction;
using UTB.Restaurant.Application.ViewModels;
using UTB.Restaurant.Models;

namespace UTB.Restaurant.Controllers;

public class HomeController(ILogger<HomeController> logger,
                          IHomeService homeService) : Controller
{

    public IActionResult Index()
    {
        CarouselProductViewModel viewModel = homeService.GetIndexViewModel();
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

