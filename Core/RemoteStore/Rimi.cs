namespace PriceMonitor.Core.RemoteStore;

using PriceMonitor.Domain;

public class Rimi : IRemoteStore {
    System.Net.Http.HttpClient HttpClient;

    public Rimi(System.Net.Http.HttpClient httpClient) {
        HttpClient = httpClient;
    }

    public async Task<StoreProductPrice> FetchCurrentPriceAsync(StoreProduct storeProduct) {
        var productId = "maiustused-ja-snakid/kuivatatud-puuviljad-ja-pahklid/pahklid/india-pahkel-rimi-150g/p/805562";
        var requestString = $"https://www.rimi.ee/epood/ee/tooted/{storeProduct.ApiString}";
        var message = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, requestString);
        using var response1 = await HttpClient.SendAsync(message, System.Net.Http.HttpCompletionOption.ResponseHeadersRead);
        using var response2 = response1.EnsureSuccessStatusCode();
        var content = await response2.Content.ReadAsStringAsync();
        var parseAmount = () => {
            var amountString =
                new System.Text.RegularExpressions.Regex("\"price\": \\d+.\\d+")
                .Match(content).Value
                .Replace("\"price\": ", "");
            return decimal.Parse(amountString);
        };
        var price = new StoreProductPrice {
            StoreProductId = storeProduct.StoreProductId,
            Amount = parseAmount(),
        };
        return price;
    }
}
