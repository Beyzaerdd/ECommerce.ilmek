﻿using ECommerce.Entity.Concrete;
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
    public class UserFavConfiguration : IEntityTypeConfiguration<UserFav>
    {
        public void Configure(EntityTypeBuilder<UserFav> builder)
        {




            builder
                 .HasOne(uf => uf.Product)
                 .WithMany(p => p.UserFavs)
                 .HasForeignKey(uf => uf.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
