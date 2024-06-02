namespace PriceMonitor.Core.RemoteStore;

using PriceMonitor.Domain;
using System.Text.Json.Nodes;

public class Selver : IRemoteStore {
    System.Net.Http.HttpClient HttpClient;

    public Selver(System.Net.Http.HttpClient httpClient) {
        HttpClient = httpClient;
    }

    public async Task<StoreProductPrice> FetchCurrentPriceAsync(StoreProduct storeProduct) {
        var requestString = $"https://www.selver.ee/api/catalog/vue_storefront_catalog_et/product/_search?from=0&request=%7B%22query%22%3A%7B%22bool%22%3A%7B%22filter%22%3A%7B%22terms%22%3A%7B%22url_path%22%3A%5B%22{storeProduct.ApiString}%22%5D%7D%7D%7D%7D%7D&size=50&sort=";
        var message = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, requestString);
        using var response1 = await HttpClient.SendAsync(message, System.Net.Http.HttpCompletionOption.ResponseHeadersRead);
        using var response2 = response1.EnsureSuccessStatusCode();
        var stream = await response2.Content.ReadAsStreamAsync();
        var json = JsonNode.Parse(stream);
        var priceJson = json["hits"]["hits"][0]["_source"]["prices"][0];
        decimal amount = (decimal)priceJson["price"];
        var price = new StoreProductPrice {
            StoreProductId = storeProduct.StoreProductId,
            Amount = amount,
        };
        return price;
    }
}
