using Microsoft.EntityFrameworkCore;
using product_service_api.Data;
using product_service_api.Model;

namespace product_service_api.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> FindAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> FindByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> SaveAsync(Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
    }
}