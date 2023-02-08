using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MCommissionRate:EntityBase,IEntity
    {
        public int UserId { get; set; }
        public decimal? Rate { get; set; }
        public string? Name { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
    }
}
