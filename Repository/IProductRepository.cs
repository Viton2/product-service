using product_service_api.Model;

namespace product_service_api.Repository;

public interface IProductRepository
{
    Task<List<Product>> FindAllAsync();

    Task<Product?> FindByIdAsync(Guid id);

    Task<Product> SaveAsync(Product product);

    Task DeleteAsync(Product product);
}