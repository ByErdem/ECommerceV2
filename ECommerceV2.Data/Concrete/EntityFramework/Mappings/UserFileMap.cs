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
    public class UserFileMap : IEntityTypeConfiguration<MUserFile>
    {
        public void Configure(EntityTypeBuilder<MUserFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Keywords).HasMaxLength(500);
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.Property(x => x.FileType).HasMaxLength(20);
            builder.Property(x => x.Path).HasMaxLength(300);
            builder.ToTable("Tbl_UserFiles");

        }
    }
}
