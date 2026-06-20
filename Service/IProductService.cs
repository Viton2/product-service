using product_service_api.DTO;
using product_service_api.Model;

namespace product_service_api.Service;

public interface IProductService
{
    Task<List<ProductDTO>> FindAllAsync();

    Task<ProductDTO?> FindByIdAsync(Guid id);

    Task<ProductDTO> CreateAsync(CreateProduct product);
    Task<Product> UpdateAsync(Guid id, Product product);

    Task DeleteAsync(Guid id);

}