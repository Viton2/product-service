using System.ComponentModel.DataAnnotations;
using product_service_api.DTO;

namespace product_service_api.Model;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public Product (CreateProduct dto)
    {
        Id = Guid.NewGuid();
        Name = dto.Name;
        CreatedAt = DateTime.UtcNow;
        Price = dto.Price;
        Description = dto.Description;
    }
    public Product(){}
}