using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;

namespace EcommerceV2.Entities.Concrete
{
    public class MStock : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Buying Price:
        /// Müşterilerin aldıkları malların alış fiyatlarını takip ederek girmesi gerekir. 
        /// Buradaki amaç satış işlemi gerçekleştiğinde Actions tablosunda oluşan kârları hesaplayabilmektir.
        /// </summary>
        public decimal BuyingPrice { get; set; } 
        public decimal UnitPrice { get; set; }
        public string? Keywords { get; set; }
        public string? Category  { get; set; }
        public string? Barcode { get; set; }
        public EUnit Unit { get; set; }
        public MUser? User { get; set; }
        public ICollection<MCommissionRate>? CommissionRates { get; set; }
    }
}