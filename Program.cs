using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using CarRentalPortal.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); 
builder.Services.AddRazorPages();
builder.Services.AddSignalR();




// _carTypeRepository nesnesinin olu�turulmas�n� sa�l�yor => Dependency Injection
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>(); //var
builder.Services.AddScoped<ICarRepository, CarRepository>();         //var
builder.Services.AddScoped<IRentalRepository, RentalRepository>();   //var
builder.Services.AddScoped<IEmailSender, EmailSender>();


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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chatHub");


app.Run();
