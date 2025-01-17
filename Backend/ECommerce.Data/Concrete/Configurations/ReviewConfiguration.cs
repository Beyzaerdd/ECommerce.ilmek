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
    public  class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
       
    
        public void Configure(EntityTypeBuilder<Review> builder)
        {
           
            builder
                 .HasOne(r => r.OrderItem) 
                 .WithMany(oi => oi.Reviews)
                 .HasForeignKey(r => r.OrderItemId) 
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

