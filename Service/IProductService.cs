using product_service_api.Model;

namespace product_service_api.Service;

public interface IProductService
{
    Task<List<Product>> FindAllAsync();

    Task<Product?> FindByIdAsync(Guid id);

    Task<Product> CreateAsync(Product product);

    Task DeleteAsync(Guid id);
}