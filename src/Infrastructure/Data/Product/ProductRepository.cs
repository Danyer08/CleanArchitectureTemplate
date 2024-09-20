using Application.Product.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Product;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        var result = await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ProductEntity> UpdateAsync(ProductEntity entity)
    {
        var result = _context.Products.Update(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Products.FindAsync(id);
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
    }
}