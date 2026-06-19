using product_service_api.DTO;
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

    public async Task<ProductDTO?> FindByIdAsync(Guid id)
    {
        return ConvertProductModelToDto(await _repository.FindByIdAsync(id));
    }

    public async Task<Product> CreateAsync(CreateProduct productRequest)
    {
        Product product = new(productRequest);
        // product.Id = Guid.NewGuid();
        // product.Name = productRequest.Name;
        // product.Price = productRequest.Price;
        // product.Description = productRequest.Description;

        return await _repository.SaveAsync(product);
    }
    
    public async Task<Product> UpdateAsync(Guid id, Product product)
    {
        var existingProduct = await _repository.FindByIdAsync(id);

        if (existingProduct == null)
            throw new Exception("Product not found");

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Description = product.Description;

        return await _repository.UpdateAsync(existingProduct);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _repository.FindByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        await _repository.DeleteAsync(product);
    }

    private static ProductDTO ConvertProductModelToDto(Product product)
    {
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        ProductDTO dto = new(product);
        // dto.Id = product.Id;
        // dto.Name = product.Name;
        // dto.Price = product.Price;
        // dto.Description = product.Description;
        return dto;
    }
}