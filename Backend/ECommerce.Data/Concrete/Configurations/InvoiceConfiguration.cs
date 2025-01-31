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
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
              .HasOne(ı => ı.Order)
              .WithOne(o => o.Invoice)
              .HasForeignKey<Invoice>(ı => ı.OrderId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
              .Property(b => b.Address)
              .IsRequired()
              .HasMaxLength(500);

         

            builder
            .Property(b => b.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        }
    }
}
