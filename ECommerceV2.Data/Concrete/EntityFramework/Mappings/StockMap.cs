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
            builder.Property(x => x.Category).HasMaxLength(250);
            builder.Property(x => x.BuyingPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Unit).HasMaxLength(20);
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CreatedByUserUniqueId).IsRequired();
            builder.Property(x => x.CreatedByUserUniqueId).HasMaxLength(100);
            builder.Property(x => x.ModifiedByUserUniqueId).IsRequired();
            builder.Property(x => x.ModifiedByUserUniqueId).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.ToTable("Stocks");

            builder.HasMany(x => x.CommissionRates).WithOne(x => x.Stock).HasForeignKey(x => x.StockId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
