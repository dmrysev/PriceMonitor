using System.ComponentModel.DataAnnotations;

namespace PriceMonitor.Domain;

public class Product {
    public int ProductId { get; set; }
    [Required] public string Name { get; set; }
    public List<ProductTag> Tags { get; set; } = [];
}
