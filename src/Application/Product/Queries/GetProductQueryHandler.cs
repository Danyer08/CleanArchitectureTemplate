using Domain.Entities;
using Application.Product.Interfaces;

namespace Application.Product.Queries;
public class GetProductQueryHandler(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<ProductEntity> GetAsync(Guid id)
    {
        return await _productRepository.GetAsync(id);
    }
}