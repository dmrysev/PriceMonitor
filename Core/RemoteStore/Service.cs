namespace PriceMonitor.Core.RemoteStore;

using PriceMonitor;
using PriceMonitor.Domain;

public class Service {
    private readonly System.Net.Http.HttpClient HttpClient;
    private readonly Dictionary<int, IRemoteStore> RemoteStores;
    private readonly Data.PriceMonitorContext PriceMonitorContext;

    public Service(
        HttpClient httpClient,
        Data.PriceMonitorContext priceMonitorContext) 
    {
        HttpClient = httpClient;
        PriceMonitorContext = priceMonitorContext;
        var stores = PriceMonitorContext.Stores.ToList();
        var getStoreId = (string name) => stores.First(s => s.Name == name).StoreId;
        RemoteStores = new () {
            { getStoreId(nameof(Selver)), new Selver(HttpClient) },
            { getStoreId(nameof(Rimi)), new Rimi(HttpClient) },
        };
    }

    public async Task UpdatePricesAsync() {
        var updateTasks =
            PriceMonitorContext.StoreProducts
            .Select(sp => RemoteStores[sp.StoreId].FetchCurrentPriceAsync(sp));
        var prices = await Task.WhenAll(updateTasks);
        PriceMonitorContext.StoreProductPrices.AddRange(prices);
        await PriceMonitorContext.SaveChangesAsync();
    }
}
