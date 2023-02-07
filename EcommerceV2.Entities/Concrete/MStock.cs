using ECommerceV2.Shared.Entities.Abstract;

namespace EcommerceV2.Entities.Concrete
{
    public class MStock : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? VideoPath { get; set; }
        public string? ImagePath { get; set; }
    }
}