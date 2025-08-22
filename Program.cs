using dotnet_inmob_primer_entrega.Models; // Agregá esta línea
using Microsoft.EntityFrameworkCore; // Agregá esta línea
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Opcional para la versión MySQL

var builder = WebApplication.CreateBuilder(args);

// Agregar la cadena de conexión al appsettings.json (ver más abajo)

// Agregamos el DbContext y le indicamos usar MySQL con la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29))) // Cambia la versión si usás otra
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();



