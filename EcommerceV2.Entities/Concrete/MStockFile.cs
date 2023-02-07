using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MStockFile:EntityBase,IEntity
    {
        public int StockId { get; set; }
        public string? Name { get; set; }
        public string? Ext { get; set; }
        public string? Path { get; set; }
        public FileType FileType { get; set; } 
    }
}
