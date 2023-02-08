using ECommerceV2.Shared.Entities.Abstract;

namespace EcommerceV2.Entities.Concrete
{
    public class MStock : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Keywords { get; set; }
        public MUser? User { get; set; }
        public ICollection<MCommissionRate>? CommissionRates { get; set; }
    }
}