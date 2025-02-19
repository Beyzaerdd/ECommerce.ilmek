
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
using ECommerce.Shared.ComplexTypes;


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

          


            // Default roles
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "115c7796-cfac-44de-91b5-916eaae125b5", Name = "Admin", NormalizedName = "ADMIN", Description = "Administrator role" },
                new ApplicationRole { Id = "811f466c-9d06-43f8-a054-24aedbb4161b", Name = "NormalUser", NormalizedName = "NORMALUSER", Description = "Regular user role" },
                new ApplicationRole { Id = "811f466c-9d06-43f8-a054-24aedbb4161c", Name = "Seller", NormalizedName = "SELLER", Description = "Seller role" }
            );

            // Default users
            var hasher = new PasswordHasher<ApplicationUser>();

            // AdminUser
            var admin = new Admin
            {
                Id = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                UserName = "adminuser@gmail.com",
                NormalizedUserName = "ADMINUSER@GMAIL.COM",
                Email = "adminuser@gmail.com",
                NormalizedEmail = "ADMINUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                Address = "",
                PhoneNumber = "",
        
                DateOfBirth = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };

            // NormalUser
            var normalUser = new NormalUser
            {
                Id = "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                UserName = "normaluser@gmail.com",
                NormalizedUserName = "NORMALUSER@GMAIL.COM",
                Email = "normaluser@gmail.com",
                NormalizedEmail = "NORMALUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Normal",
                LastName = "User",
                Address = "aa",
                PhoneNumber = "",
         
                DateOfBirth = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };

            // SellerUser
            var seller = new Seller
            {
                Id = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                UserName = "selleruser@gmail.com",
                NormalizedUserName = "SELLERUSER@GMAIL.COM",
                Email = "selleruser@gmail.com",
                NormalizedEmail = "SELLERUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Seller",
                IdentityNumber = "1",
                LastName = "User",
                StoreName = "Store",
                IsApproved = true,
                IsActive = true,
                Address = "",
                PhoneNumber = "",
                WeeklyOrderLimit =10,
                DateOfBirth = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };

            modelBuilder.Entity<Admin>().HasData(admin);
            modelBuilder.Entity<NormalUser>().HasData(normalUser);
            modelBuilder.Entity<Seller>().HasData(seller);

            // Assign roles to users
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = "115c7796-cfac-44de-91b5-916eaae125b5" },
                new IdentityUserRole<string> { UserId = normalUser.Id, RoleId = "811f466c-9d06-43f8-a054-24aedbb4161b" },
                new IdentityUserRole<string> { UserId = seller.Id, RoleId = "811f466c-9d06-43f8-a054-24aedbb4161c" }
            );

            // Basket data
            modelBuilder.Entity<Basket>().HasData(
                new Basket { Id = 1, ApplicationUserId = admin.Id },
                new Basket { Id = 2, ApplicationUserId = normalUser.Id },
                new Basket { Id = 3, ApplicationUserId = seller.Id }
            );




        }

    }



    }









