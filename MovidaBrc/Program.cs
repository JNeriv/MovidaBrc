using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MovidaBrc.Data;
using MovidaBrc.Repositories;
using MovidaBrc.Services;
using MovidaBrcSharedLibrary.Contracts;
using MovidaBrcSharedLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Conexión con la base de datos arranca

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Error al conectar con la Base de Datos"));
});
builder.Services.AddScoped<IFiesta, FiestaRepository>();

// Conexión con la base de datos termina

// Agregar el servicio de eliminación de eventos
builder.Services.AddHostedService<EventCleanupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
