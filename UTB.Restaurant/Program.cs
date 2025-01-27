using Microsoft.EntityFrameworkCore;
using UTB.Restaurant.Infrastructure.Database;
using UTB.Restaurant.Application.Abstraction; 
using UTB.Restaurant.Application.Implementation;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurant.Infrastructure.Identity;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata;
using UTB.Restaurant.Application.Services;

var builder = WebApplication.CreateBuilder(args);

var cultInfo = new CultureInfo("cs-cz");
CultureInfo.DefaultThreadCurrentCulture = cultInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultInfo;

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.38");
builder.Services.AddDbContext<RestaurantDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));

builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<RestaurantDbContext>()
     .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IFileUploadService, FileUploadService>(serviceProvider => new FileUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath));
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ICarouselAppService, CarouselAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IAccountService, AccountIdentityService>();
builder.Services.AddScoped<ISecurityService, SecurityIdentityService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
