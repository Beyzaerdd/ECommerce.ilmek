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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerce.Business.Configuration;


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
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));


var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig?.Issuer,
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? ""))
    };
});


builder.Services.AddDbContext<ECommerceDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SellerPolicy", policy =>
        policy.RequireRole("Seller"));

    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("SellerAndAdmin", policy =>
        policy.RequireRole("Seller", "Admin"));

    options.AddPolicy("UserPolicy", policy =>
        policy.RequireRole("User","Admin", "NormalUser"));

});

builder.Services.AddControllersWithViews();

var app = builder.Build();







if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
