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
    public class ReceivedMessageMap : IEntityTypeConfiguration<MReceivedMessage>
    {
        public void Configure(EntityTypeBuilder<MReceivedMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.SenderId).IsRequired();
            builder.Property(x => x.ReceiverId).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(1000);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.ToTable("Tbl_ReceivedMessages");

            builder.HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
