namespace PriceMonitor.Core.RemoteStore;

using PriceMonitor.Domain;

interface IRemoteStore {
    Task<StoreProductPrice> FetchCurrentPriceAsync(StoreProduct storeProduct);
}
