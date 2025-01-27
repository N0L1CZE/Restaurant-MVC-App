using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Infrastructure.Database.Seeding
{
    internal class ProductInit
    {
        public IList<Product> GetProductsFood3()
        {
            IList<Product> products = new List<Product>();

            products.Add(new Product
            {
                Id = 1,
                Name = "Pizza",
                Description = "Prostě Pizza!",
                Price = 150,
                ImageSrc = "/img/products/product1.jpg"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Závitky",
                Description = "Jarní vietnamské závitky, prostě mňamka",
                Price = 80,
                ImageSrc = "/img/products/product2.jpg"
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Kachna se zelím a bramborovým knedlíkem",
                Description = "Prostě kachna",
                Price = 130,
                ImageSrc = "/img/products/product3.jpg"
            });

            return products;
        }
    }
}
