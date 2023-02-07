using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MImage:EntityBase,IEntity
    {
        public int StockId { get; set; }
        public string? Name { get; set; }
        public string? Ext { get; set; }
        public string? Path { get; set; }
    }
}
