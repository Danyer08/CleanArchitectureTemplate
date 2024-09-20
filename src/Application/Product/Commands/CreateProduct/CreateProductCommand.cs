namespace Application.Product.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price);