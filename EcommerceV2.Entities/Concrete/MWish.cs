using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MWish:EntityBase,IEntity
    {
        public int UserId { get; set; }
        public int StockId { get; set; }
        public string? StockName { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
