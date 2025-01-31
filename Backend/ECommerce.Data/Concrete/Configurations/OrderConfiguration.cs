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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder
                .HasOne(o => o.Invoice)
                .WithOne(i => i.Order)  // Invoice ile ilişkiyi tanımlıyoruz
                .HasForeignKey<Order>(o => o.InvoiceId) // InvoiceId foreign key olarak belirliyoruz
                .OnDelete(DeleteBehavior.Restrict);  // Silme davranışı

            builder
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
