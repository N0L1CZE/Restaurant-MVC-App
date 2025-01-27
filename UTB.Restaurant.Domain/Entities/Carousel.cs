using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Restaurant.Domain.Entities
{
    [Table(nameof(Carousel))]
    public class Carousel : Entity<int>
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}
