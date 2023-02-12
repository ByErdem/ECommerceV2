﻿using EcommerceV2.Entities.Concrete;
using ECommerceV2.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Concrete.EntityFramework.Repositories
{
    public class EfSentMessageRepository : EfEntityRepositoryBase<MSentMessage>
    {
        public EfSentMessageRepository(DbContext context) : base(context)
        {
        }
    }
}
