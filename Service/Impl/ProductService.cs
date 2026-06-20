using AutoMapper;
using product_service_api.DTO;
using product_service_api.Exceptions;
using product_service_api.Model;
using product_service_api.Repository;

namespace product_service_api.Service.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository,  IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> FindAllAsync()
    {
        var products = await _repository.FindAllAsync();

        return products.Select(ConvertProductModelToDto).ToList();
    }

    public async Task<ProductDTO?> FindByIdAsync(Guid id)
    {
        return ConvertProductModelToDto(await _repository.FindByIdAsync(id));
    }

    public async Task<ProductDTO> CreateAsync(CreateProduct productRequest)
    {
        Product product = new(productRequest);
        return ConvertProductModelToDto(product);
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

    private ProductDTO ConvertProductModelToDto(Product product)
    {
        return product == null ? throw new NotFoundException($"Produto não encontrado") : _mapper.Map<ProductDTO>(product);
    }
}