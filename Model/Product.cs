using System.ComponentModel.DataAnnotations;

namespace product_service_api.Model;

public class Product
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Range(typeof(decimal), "0.01", "999999.99", ErrorMessage = "Price must be between 0.01 and 999999.99")]
    public decimal Price { get; set; }
    
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}