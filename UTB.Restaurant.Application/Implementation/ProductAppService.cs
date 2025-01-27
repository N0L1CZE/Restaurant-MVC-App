using UTB.Restaurant.Application.Abstraction;
using UTB.Restaurant.Domain.Entities;
using UTB.Restaurant.Infrastructure.Database;

namespace UTB.Restaurant.Application.Implementation
{
    public class ProductAppService(RestaurantDbContext restaurantDbContext, IFileUploadService fileUploadService) : IProductAppService
    {

        public IList<Product> Select()
        {
            return restaurantDbContext.Products.ToList();
        }

        public void Create(Product product)
        {
            if (product.Image != null)
            {
                string imageSrc = fileUploadService.FileUpload(product.Image, Path.Combine("img", "products"));
                product.ImageSrc = imageSrc;
            }

            restaurantDbContext.Products.Add(product);
            restaurantDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product
                = restaurantDbContext.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                restaurantDbContext.Products.Remove(product);
                restaurantDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
    }
}

