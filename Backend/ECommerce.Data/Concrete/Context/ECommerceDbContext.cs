
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

            modelBuilder.Entity<ApplicationUser>()

                .HasOne(p => p.Basket)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(P => P.BasketId);

            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Woman", Description = "Woman", ImageUrl="x" },
             new Category { Id = 2, Name = "Man", Description = "Man", ImageUrl = "x" },
             new Category { Id = 3, Name = "Baby", Description = "Baby", ImageUrl = "x" },
             new Category { Id = 4, Name = "Home", Description = "Home", ImageUrl = "x" },
             new Category { Id = 5, ParentCategoryId = 1, Name = "Woman Top clothing", Description = "Top clothing" },
             new Category { Id = 6, ParentCategoryId = 2, Name = "Man Top clothing", Description = "Top clothing" },
             new Category { Id = 7, ParentCategoryId = 3, Name = "Baby Top clothing", Description = "Top clothing" },
             new Category { Id = 8, ParentCategoryId = 4, Name = "Home Blanket", Description = "Blanket" });


            // Default roles
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "115c7796-cfac-44de-91b5-916eaae125b5", Name = "AdminUser", NormalizedName = "ADMINUSER", Description = "Administrator role" },
                new ApplicationRole { Id = "811f466c-9d06-43f8-a054-24aedbb4161b", Name = "NormalUser", NormalizedName = "NORMALUSER", Description = "Regular user role" },
                new ApplicationRole { Id = "811f466c-9d06-43f8-a054-24aedbb4161c", Name = "Seller", NormalizedName = "SELLER", Description = "Seller role" }
            );

            // Default users
            var hasher = new PasswordHasher<ApplicationUser>();

            // AdminUser
            var adminUser = new Admin
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
                City = "",
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
                Address = "",
                PhoneNumber = "",
                City = "",
                DateOfBirth = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };

            // SellerUser
            var sellerUser = new Seller
            {
                Id = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
                UserName = "selleruser@gmail.com",
                NormalizedUserName = "SELLERUSER@GMAIL.COM",
                Email = "selleruser@gmail.com",
                NormalizedEmail = "SELLERUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Seller",
                IdentityNumber = 1,
                LastName = "User",
                StoreName = "Store",
                Address = "",
                PhoneNumber = "",
                City = "",
                DateOfBirth = DateTime.Now,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };

            modelBuilder.Entity<Admin>().HasData(adminUser);
            modelBuilder.Entity<NormalUser>().HasData(normalUser);
            modelBuilder.Entity<Seller>().HasData(sellerUser);

            // Assign roles to users
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "115c7796-cfac-44de-91b5-916eaae125b5" },
                new IdentityUserRole<string> { UserId = normalUser.Id, RoleId = "811f466c-9d06-43f8-a054-24aedbb4161b" },
                new IdentityUserRole<string> { UserId = sellerUser.Id, RoleId = "811f466c-9d06-43f8-a054-24aedbb4161c" }
            );

            // Basket data
            modelBuilder.Entity<Basket>().HasData(
                new Basket { Id = 1, ApplicationUserId = adminUser.Id },
                new Basket { Id = 2, ApplicationUserId = normalUser.Id },
                new Basket { Id = 3, ApplicationUserId = sellerUser.Id }
            );



            modelBuilder.Entity<Product>().HasData(
          new Product
          {
              Id = 1,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Silk Blouse",
              Description = "Elegant silk blouse for women.",
              UnitPrice = 49.99m,
              Size = ProductSize.M,
              Color = ProductColor.White,
              PreparationTimeInDays = 3,
              IsActive = true,
              CategoryId = 1,
              SubcategoryId = 5,
              ImageUrl = "https://example.com/images/silk-blouse.jpg"
          },
          new Product
          {
              Id = 2,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Men's Casual Shirt",
              Description = "Comfortable and stylish casual shirt for men.",
              UnitPrice = 34.99m,
              Size = ProductSize.L,
              Color = ProductColor.Blue,
              PreparationTimeInDays = 2,
              IsActive = true,
              CategoryId = 2,
              SubcategoryId = 6,
              ImageUrl = "https://example.com/images/mens-casual-shirt.jpg"
          },
          new Product
          {
              Id = 3,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Baby Pajamas",
              Description = "Soft pajamas for babies.",
              UnitPrice = 14.99m,
              Size = ProductSize.Newborn,
              Color = ProductColor.Pink,
              PreparationTimeInDays = 2,
              IsActive = true,
              CategoryId = 3,  // Baby Category
              SubcategoryId = 7, // Baby Top Clothing
              ImageUrl = "https://example.com/images/baby-pajamas.jpg"
          },
          new Product
          {
              Id = 4,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Baby Shoes",
              Description = "Comfortable shoes for babies.",
              UnitPrice = 25.99m,
              Size = ProductSize.EarlySchoolAge,
              Color = ProductColor.Yellow,
              PreparationTimeInDays = 4,
              IsActive = true,
              CategoryId = 3,  // Baby Category
              SubcategoryId = 7, // Baby Shoes
              ImageUrl = "https://example.com/images/baby-shoes.jpg"
          },
          new Product
          {
              Id = 5,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Home Blanket",
              Description = "Soft and warm blanket for home.",
              UnitPrice = 39.99m,
              Size = ProductSize.L,
              Color = ProductColor.Blue,
              PreparationTimeInDays = 3,
              IsActive = true,
              CategoryId = 4,  // Home Category
              SubcategoryId = 8, // Home Blanket
              ImageUrl = "https://example.com/images/home-blanket.jpg"
          },
          new Product
          {
              Id = 6,
              ApplicationUserId = "cfc0c1b1-e663-4c5e-b747-255c6c40b4c6",
              Name = "Home Furniture Set",
              Description = "Comfortable furniture set for home.",
              UnitPrice = 499.99m,
              Size = ProductSize.L,
              Color = ProductColor.Brown,
              PreparationTimeInDays = 7,
              IsActive = true,
              CategoryId = 4,  // Home Category
              SubcategoryId = 8, // Home Furniture
              ImageUrl = "https://example.com/images/home-furniture-set.jpg"
          }
      );

        }

    }



    }









