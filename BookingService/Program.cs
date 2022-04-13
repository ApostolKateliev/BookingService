using BookingService.Core.Constants;
using BookingService.Infrastructure.Data;
using BookingService.ModelBinders;
using BookingService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingService.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using BookingService.Infrastructure.Data.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddApplicationDbContexts(builder.Configuration);

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();




builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration.GetValue<string>("Facebook:AppId");
    options.AppSecret = builder.Configuration.GetValue<string>("Facebook:AppSecret");
});

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(FormatingConstant.NormalDateFormat));
    });

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseStatusCodePages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Authentication should be first
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();