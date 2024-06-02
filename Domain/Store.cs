namespace PriceMonitor.Domain;

public class Store {
    public int StoreId { get; set; }
    public string Name { get; set; }
    public List<StoreProduct> StoreProducts { get; set; } = [];
}
