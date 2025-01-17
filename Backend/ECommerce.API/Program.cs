using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Data.Concrete.Context;
using ECommerce.Data.Concrete.Repositories;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
    //options.User.AllowedUserNameCharacters = "abcdefghijklmnoqprstuvwxyz0123456789-_.@";

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<ECommerceDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();
//var scope = app.Services.CreateScope();
//var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
//await userManager.CreateAsync(new Admin
//{
//    UserName = "admin",
//    Email = "beyza@gmail.com",
//    Address = "Istanbul",
//    City = "Istanbul",
//    FirstName = "Beyza",
//    LastName = "Kara",
//    DateOfBirth = new DateTime(1998, 12, 12),
//    PhoneNumber = "1234567890",
//    EmailConfirmed = true,
//    Basket = new Basket()
//    {

//    }



//},
//"Bsfdjdsjkjk38309."


//);
//var admin = context.Admin.First();
//context.Baskets.Add(new Basket
//{
//    ApplicationUser = admin,
//    ApplicationUserId = admin.Id
//});

//context.SaveChanges();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
