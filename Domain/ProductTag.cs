using System.ComponentModel.DataAnnotations;

namespace PriceMonitor.Domain;

public class ProductTag {
    public int ProductTagId { get; set; }
    [Required] public string Value { get; set; }
}

