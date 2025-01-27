using UTB.Restaurant.Domain.Entities;

namespace UTB.Restaurant.Application.Abstraction
{
    public interface IProductAppService
    {
        IList<Product> Select();
        void Create(Product product);
        bool Delete(int id);
    }
}

