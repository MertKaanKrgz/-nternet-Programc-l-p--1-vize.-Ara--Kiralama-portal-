using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// _carTypeRepository nesnesinin olu�turulmas�n� sa�l�yor => Dependency Injection
builder.Services.AddScoped<ICarTypeRepository, CarTypeRepository>(); //var
builder.Services.AddScoped<ICarRepository, CarRepository>();         //var
builder.Services.AddScoped<IRentalRepository, RentalRepository>();   //var



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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
