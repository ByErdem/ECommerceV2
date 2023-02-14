using EcommerceV2.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Concrete.EntityFramework.Mappings
{
    public class ActionMap : IEntityTypeConfiguration<MAction>
    {
        public void Configure(EntityTypeBuilder<MAction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(250);
            builder.Property(x => x.StockName).IsRequired();
            builder.Property(x => x.StockName).HasMaxLength(250);
            builder.Property(x => x.Unit).HasMaxLength(20);
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.BuyingPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(100);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.ToTable("Tbl_Actions");

            builder.HasMany(x => x.CommissionRates).WithOne(x => x.Action).HasForeignKey(x => x.StockId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithMany(x => x.Actions).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
