using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Configurations
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
          

            builder.HasKey(bi => new { bi.BasketId, bi.ProductId });
            builder.HasKey(bi => bi.Id);

            builder
             .HasOne(bi => bi.Product)
                   .WithMany(b => b.BasketItems)
                   .HasForeignKey(bi => bi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder
            .Property(bi => bi.Quantity)
            .IsRequired()
           .HasDefaultValue(1);


            builder.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_BasketItem_Quantity", "Quantity > 0");

                });



        }
    }
}
