using System.ComponentModel.DataAnnotations;

namespace API.Product.DTOs;

public class CreateProductRequestDTO
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(500)]
    public required string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
}