using EcommerceV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public CategoryDto? Parent { get; set; }
        public List<CategoryDto>? Children { get; set; }
    }
}
