namespace PriceMonitor.Domain;

public class StoreProduct {
    public int StoreProductId { get; set; }
    public Store Store { get; set; }
    public int StoreId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public string ApiString { get; set; }
}
