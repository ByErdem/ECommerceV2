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
    public class UserMap : IEntityTypeConfiguration<MUser>
    {
        public void Configure(EntityTypeBuilder<MUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CitizenshipId).IsRequired();
            builder.Property(x => x.CitizenshipId).HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(250);
            builder.Property(x => x.LastName).HasMaxLength(250);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.District).HasMaxLength(100);
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250);
            builder.Property(x => x.Authority).IsRequired();
            builder.Property(x => x.UserPicture).HasMaxLength(250);
            builder.Property(x => x.Blocked).IsRequired();
            builder.ToTable("Tbl_Users");

            builder.HasMany(x => x.Actions).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Stocks).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SentMessages).WithOne(x => x.Receiver).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ReceivedMessages).WithOne(x => x.Sender).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);
            

        }
    }
}
