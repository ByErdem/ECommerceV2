using ECommerceV2.Shared.Entities.Abstract;

namespace EcommerceV2.Entities.Concrete
{
    public class MStock : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public decimal BuyingPrice { get; set; } 
        public decimal SellingPrice { get; set; }
        public string? Keywords { get; set; }
        public ICollection<M MyProperty { get; set; }
    }
}