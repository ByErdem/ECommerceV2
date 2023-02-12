using EcommerceV2.Entities.Concrete;
using ECommerceV2.Data.Concrete.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Concrete.EntityFramework.Contexts
{
    public class ECommerceV2Context:DbContext
    {
        public DbSet<MAction>? Actions { get; set; }
        public DbSet<MCommissionRate>? CommissionRates { get; set; }
        public DbSet<MReceivedMessage>? ReceivedMessages { get; set; }
        public DbSet<MSentMessage>? SentMessages { get; set; }
        public DbSet<MStock>? Stocks { get; set; }
        public DbSet<MStockFile>? StockFiles { get; set; }
        public DbSet<MUser>? Users { get; set; }
        public DbSet<MUserFile>? UsersFiles { get; set; }
        public DbSet<MWish>? Wishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=176.53.69.151\MSSQLSERVER2019;Initial Catalog=koderpar_ecommercev2;User Id=koderpar_ecommercev2;Password=Ucj6w426_;Trusted_Connection=false");
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new ActionMap());
            b.ApplyConfiguration(new CommissionRateMap());
            b.ApplyConfiguration(new ReceivedMessageMap());
            b.ApplyConfiguration(new SentMessageMap());
            b.ApplyConfiguration(new StockFileMap());
            b.ApplyConfiguration(new StockMap());
            b.ApplyConfiguration(new UserFileMap());
            b.ApplyConfiguration(new WishMap());
        }

    }
}
