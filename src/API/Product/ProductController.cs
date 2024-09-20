using API.Product.DTOs;
using Application.Product.Queries;
using Application.Product.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace API.Product;

[ApiController]
[Route("api/[controller]")]
public class ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler) : ControllerBase {
    private readonly GetProductQueryHandler _getProductQueryHandler = getProductQueryHandler;
    private readonly CreateProductCommandHandler _createProductCommandHandler = createProductCommandHandler;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() {
        var products = await _getProductQueryHandler.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequestDTO body) {
        var createCommand = new CreateProductCommand(body.Name, body.Description, body.Price);
        var product = await _createProductCommandHandler.ExecuteAsync(createCommand);
        return Ok(product);
    }
}