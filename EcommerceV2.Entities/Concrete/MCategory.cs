using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MCategory : IEntity
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public MCategory? Parent { get; set; }
        public List<MCategory>? Children { get; set; }

    }
}
