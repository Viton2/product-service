namespace product_service_api.Model;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
    
    public string Description { get; set; } = string.Empty;
}