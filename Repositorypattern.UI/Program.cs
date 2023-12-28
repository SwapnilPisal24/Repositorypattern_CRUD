using Microsoft.EntityFrameworkCore;
using Repositorypattern.repositories;
using Repositorypattern.Repositories.Implimentations;
using Repositorypattern.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositorypattern.UI")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI : tightly couple to Loose couple
//DI : Achive IOC (Inversion of Control) change the way of object depndencies
//     for eg. if any road is blocked then we choose another road so same we not creating
//     the object of class

builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true; // access cookies only by url insted of javascript for security purpose
});
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
