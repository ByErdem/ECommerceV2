using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MAction:EntityBase,IEntity
    {
        public int UserId { get; set; }
        public int StockId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public MStock? Stock { get; set; }
        public MUser? User { get; set; }
    }
}
