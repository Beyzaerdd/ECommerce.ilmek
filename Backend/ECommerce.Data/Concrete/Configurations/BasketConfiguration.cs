using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {

            builder.HasOne(b => b.ApplicationUser)
                    .WithOne(au => au.Basket)
                    .HasForeignKey<Basket>(b => b.ApplicationUserId);
                 
        }
    }
}
