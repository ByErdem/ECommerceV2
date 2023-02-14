using EcommerceV2.Entities.Concrete;
using ECommerceV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Abstract
{
    public abstract class MessageBase
    {
        public virtual int Id { get; set; }
        public virtual int SenderId { get; set; }
        public virtual MUser? Sender { get; set; }
        public virtual int ReceiverId { get; set; }
        public virtual MUser? Receiver { get; set; }
        public virtual string? Content { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
    }
}
