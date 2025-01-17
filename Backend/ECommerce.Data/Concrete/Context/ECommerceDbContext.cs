
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity.Concrete;
using System.Reflection;


namespace ECommerce.Data.Concrete.Context
{
    public class ECommerceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserFav> UserFavs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ApplicationUser>()

                .HasOne(p => p.Basket)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(P => P.BasketId);

        }
    }

}






