using product_service_api.DTO;
using product_service_api.Model;

namespace product_service_api.Service;

public interface IProductService
{
    Task<List<Product>> FindAllAsync();

    Task<ProductDTO?> FindByIdAsync(Guid id);

    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Guid id, Product product);

    Task DeleteAsync(Guid id);

}