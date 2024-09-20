using Application.Product.Interfaces;
using Domain.Entities;

namespace Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository) {
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Guid> ExecuteAsync(CreateProductCommand command) {
        var product = new ProductEntity {
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            CreatedAt = DateTime.UtcNow
        };
        await _productRepository.CreateAsync(product);
        return product.Id;
    }
}