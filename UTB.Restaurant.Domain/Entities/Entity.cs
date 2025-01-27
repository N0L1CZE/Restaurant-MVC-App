using UTB.Restaurant.Domain.Entities.Interfaces;

namespace UTB.Restaurant.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
