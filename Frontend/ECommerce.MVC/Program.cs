using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Services.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using NToastNotify;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNToastNotifyToastr(new ToastrOptions
                {
                    ProgressBar = true,
                    PositionClass =ToastPositions.TopRight,
                    CloseButton = true,
                    TimeOut = 5000,
                    ShowDuration = 1000,
                    HideDuration = 1000,
                    ShowEasing="swing",
                    HideEasing="linear",
                    ShowMethod="fadeIn",
                    HideMethod="fadeOut"

                });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEnumService, EnumService>();
builder.Services.AddScoped<IUserAccountManagerService, UserAccountManagerService>();
builder.Services.AddHttpClient("ECommerceAPI", client => client.BaseAddress = new Uri("http://localhost:1406/api/"));

builder
    .Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ECommerce.Auth";
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.Cookie.HttpOnly = true;
    });

builder.Services.AddAuthorization();

#region DataProtection
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "keys")))
    .SetApplicationName("ECommerce.MVC")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14));

builder.Services.AddDistributedMemoryCache();

builder.Logging.AddConsole();
#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
