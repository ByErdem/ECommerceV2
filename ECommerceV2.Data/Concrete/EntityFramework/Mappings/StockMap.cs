﻿using EcommerceV2.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Concrete.EntityFramework.Mappings
{
    public class StockMap : IEntityTypeConfiguration<MStock>
    {
        public void Configure(EntityTypeBuilder<MStock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.BuyingPrice).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.TaxRate1).IsRequired();
            builder.Property(x => x.TaxRate2).IsRequired();
            builder.Property(x => x.TaxRate3).IsRequired();
            builder.Property(x => x.TaxRate4).IsRequired();
            builder.Property(x => x.TaxRate5).IsRequired();
            builder.Property(x => x.TaxRate6).IsRequired();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(100);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Tbl_Stocks");
        }
    }
}
