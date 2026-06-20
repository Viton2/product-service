using FluentValidation;
using FluentValidation.AspNetCore;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using product_service_api.Data;
using product_service_api.Mapping;
using product_service_api.Middleware;
using product_service_api.Repository;
using product_service_api.Service;
using product_service_api.Service.Impl;
using product_service_api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Keycloak Config
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddKeycloakWebApi(builder.Configuration);
builder.Services
    .AddAuthorization()
    .AddKeycloakAuthorization()
    .AddAuthorizationBuilder()
    .AddPolicy(
        "Policy",
        policy => policy.RequireResourceRoles("admin"));
            // "product-service-api", // client conforme configurado no Keycloak
            // ["admin"] // Roles necessárias (Nome da role definida lá no Keycloak)


builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(
    typeof(ProductProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();