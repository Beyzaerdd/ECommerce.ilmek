using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnType("nvarchar(50)");
            builder.Property(p => p.Description)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnType("nvarchar(100)");

            builder.HasOne(p => p.Category)
                       .WithMany(c => c.Products)
                       .HasForeignKey(p => p.CategoryId)
                       .OnDelete(DeleteBehavior.Restrict);






            builder.Property(oi => oi.IsDeleted)
          .HasDefaultValue(false);

        }
    }
}
