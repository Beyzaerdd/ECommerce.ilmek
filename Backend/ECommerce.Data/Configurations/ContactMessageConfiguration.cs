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
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder
                .Property(cm => cm.FullName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            builder
            .Property(cm => cm.Subject)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnType("nvarchar(100)");

            builder
            .Property(cm => cm.Message)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("nvarchar(500)");


            builder
            .HasOne(cm => cm.User)
            .WithMany(u => u.ContactMessages)
            .HasForeignKey(cm => cm.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
