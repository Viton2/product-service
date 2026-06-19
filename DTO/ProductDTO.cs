using product_service_api.Model;

namespace product_service_api.DTO;

public class ProductDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public ProductDTO (Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
        Description = product.Description;
    }
    
    public ProductDTO()
    {}
}