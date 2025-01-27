using Microsoft.AspNetCore.Mvc;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Application.Abstraction;
using Microsoft.AspNetCore.Authorization;
using UTB.Restaurant.Infrastructure.Identity.Enums;

namespace UTB.Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ProductController(IProductAppService productAppService) : Controller
    {
        public IActionResult Select()
        {
            IList<Product> products = productAppService.Select();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productAppService.Create(product);

                return RedirectToAction(nameof(ProductController.Select));
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = productAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(ProductController.Select));
            }
            else
                return NotFound();
        }
    }
}

