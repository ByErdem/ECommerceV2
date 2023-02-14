using EcommerceV2.Entities.Concrete;
using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<MUser>? Users { get; set; }
    }
}
