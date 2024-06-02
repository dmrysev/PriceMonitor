namespace PriceMonitor.Domain;

public class StoreProductPrice {
    public int StoreProductPriceId { get; set; }
    public StoreProduct StoreProduct { get; set; }
    public int StoreProductId { get; set;}
    public DateTime DateTimeUTC { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public Currency Currency { get; set; } = Currency.EUR;
    public bool HasDiscount { get; set; } = false;
}
