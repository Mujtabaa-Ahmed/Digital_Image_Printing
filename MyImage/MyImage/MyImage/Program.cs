using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyImage.DB_Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DB_context>(option =>
{
    option.UseSqlServer("Server=DESKTOP-S8MJFJ5;Database=db_myimage;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True");
});
//For Server
//Server=.;passward=aptech;Database=db_myimage;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True
//for Home
//Server=DESKTOP-S8MJFJ5;Database=db_myimage;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(30);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
    (
        log =>
        {
            log.LoginPath = "/Home/Login";
            log.AccessDeniedPath = "/Home/Login";
        }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
