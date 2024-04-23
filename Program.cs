using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantProject.Data;
using RestaurantProject.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServicioPlatos, ServicioPlatos>();
builder.Services.AddScoped<IServicioReservas, ServicioReservas>();
builder.Services.AddScoped<IServicioVentas, ServicioVentas>();
//builder.Services.AddScoped<IServicioClientes, ServicioClientes>();

builder.Services.AddDbContext<RestaurantProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantProjectContext") ?? throw new InvalidOperationException("Connection string 'RestaurantProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Platos}/{action=Index}/{id?}");
app.Run();
