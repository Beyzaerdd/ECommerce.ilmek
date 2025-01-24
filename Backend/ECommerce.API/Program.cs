using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Business.Mapping;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Data.Concrete.Context;
using ECommerce.Data.Concrete.Repositories;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ECommerce.Business.Mapping;
using ECommerce.Shared.ComplexTypes;
using Microsoft.OpenApi.Validations;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;

    options.User.RequireUniqueEmail = true;
   

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<ECommerceDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
await userManager.CreateAsync(new ApplicationUser
{
    UserName = "admin",
    Email = "beyza@com",
    EmailConfirmed = true,
    FirstName = "Beyza",
    LastName = "Erdoðmuþ",
    PhoneNumber = "123456789",
    Address = "sarýyer",
    City = "Ýstanbul",

    PhoneNumberConfirmed = true
}, "Admin_123456");

using (var scope1 = app.Services.CreateScope())
{
    var serviceProvider1 = scope.ServiceProvider;


    var context = serviceProvider.GetRequiredService<ECommerceDbContext>();


    context.Products.AddRange(new List<Product>
    {
        new Product
        {
            ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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
            ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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
      
        ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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
     
        ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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
      
        ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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

        ApplicationUserId ="e593c622-afdd-4010-94f1-0e8a18f4930f",
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

    });


    context.SaveChanges();
}






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
