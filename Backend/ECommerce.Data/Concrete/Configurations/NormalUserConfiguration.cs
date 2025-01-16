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
    internal class NormalUserConfiguration : IEntityTypeConfiguration<NormalUser>
    {
        public void Configure(EntityTypeBuilder<NormalUser> builder)
        {
            builder.ToTable("NormalUsers");

        }
    }
}
