# MiPrimerAPI
API REST desarrollada en ASP.NET Core como proyecto de aprendizaje dividido en tres etapas.

## Integrantes

- Esmeralda Tais Soto Escolastico | 2024-1861
- Jordi Alexander Novas Franco | 2023-1205
- Raúl Daniel Sánchez Sánchez | 2024-1755

## Tecnologías

- .NET 9 / ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger UI
- HttpClient (consumo de API externa)


## Estructura del proyecto

```
MiPrimerAPI/
│
├── Controllers/
│   ├── ProductController.cs
│   └── ExternalController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Models/
│   ├── Product.cs
│   └── User.cs
│
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
│
├── Services/
│   ├── ProductService.cs
│   └── ExternalApiService.cs
│
├── appsettings.json
└── Program.cs
```
