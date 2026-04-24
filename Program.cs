using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.Repositories;
using MiPrimerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// CAMBIO 1: Eliminamos AddOpenApi y ponemos el generador de Swagger
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

// ── Integrante 3: API Externa ──────────────────────────────────────────────
// Registramos HttpClient tipado para ExternalApiService
builder.Services.AddHttpClient<ExternalApiService>();
// ──────────────────────────────────────────────────────────────────────────

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // CAMBIO 2: Activamos Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();