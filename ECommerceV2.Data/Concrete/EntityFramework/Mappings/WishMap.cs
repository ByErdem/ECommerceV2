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
    public class WishMap : IEntityTypeConfiguration<MWish>
    {
        public void Configure(EntityTypeBuilder<MWish> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.StockName).IsRequired();
            builder.Property(x => x.StockName).HasMaxLength(250);
            builder.Property(x => x.DiscountRate).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.ToTable("Tbl_Wishes");
        }
    }
}
