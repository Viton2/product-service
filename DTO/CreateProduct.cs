namespace product_service_api.DTO;

public class CreateProduct
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    public string Description { get; set; } = string.Empty;
}