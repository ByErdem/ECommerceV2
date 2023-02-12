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
    public class StockFileMap : IEntityTypeConfiguration<MStockFile>
    {
        public void Configure(EntityTypeBuilder<MStockFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Ext).IsRequired();
            builder.Property(x => x.Ext).HasMaxLength(10);
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Path).HasMaxLength(300);
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(250);
            builder.Property(x => x.FileType).IsRequired();
            builder.Property(x => x.FileType).HasMaxLength(20);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(100);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.ToTable("Tbl_StockFiles");
        }
    }
}
