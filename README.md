# Product Service API

REST API for product management built with **ASP.NET Core 8**, **Entity Framework Core**, and **SQL Server**.

## Features

* Product CRUD operations
* Entity Framework Core migrations
* SQL Server integration
* Swagger/OpenAPI documentation
* Dependency Injection
* Repository & Service pattern

## Requirements

* .NET 8 SDK
* SQL Server 2022 (or compatible version)
* Docker (optional, recommended)

## Configuration

The application requires the following environment variable:

| Variable                               | Description                  |
| -------------------------------------- | ---------------------------- |
| `ConnectionStrings__DefaultConnection` | SQL Server connection string |

### Example

```text
ConnectionStrings__DefaultConnection=Server=localhost,1433;Database={DATABASE_NAME};User Id=sa;Password={YOUR_PASSWORD};TrustServerCertificate=True;
```

## Running the Application

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

The API will be available at:

```text
http://localhost:{PORT}
```

Swagger UI:

```text
http://localhost:{PORT}/swagger
```

## Database Migrations

Create a new migration:

```bash
dotnet ef migrations add MigrationName
```

Apply migrations:

```bash
dotnet ef database update
```

## Project Structure

```text
product-service-api
├── Controllers
├── Data
├── DTO
├── Migrations
├── Model
├── Repository
├── Service
├── Program.cs
└── appsettings.json
```

## Technologies

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Docker
* Git

## License

This project is intended for learning and portfolio purposes.
