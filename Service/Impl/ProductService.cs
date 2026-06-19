using product_service_api.Model;
using product_service_api.Repository;

namespace product_service_api.Service.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> FindAllAsync()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<Product?> FindByIdAsync(Guid id)
    {
        return await _repository.FindByIdAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        product.Id = Guid.NewGuid();

        return await _repository.SaveAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _repository.FindByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        await _repository.DeleteAsync(product);
    }
}