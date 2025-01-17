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
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {

            builder.HasOne(b => b.ApplicationUser)
               .WithMany(au => au.Discounts)
               .HasForeignKey(b => b.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
