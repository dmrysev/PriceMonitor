using Microsoft.EntityFrameworkCore;
using PriceMonitor;
using PriceMonitor.Data;
using PriceMonitor.Domain;

using var context = new PriceMonitorContext();
context.Database.EnsureCreated();

SeedData();
void SeedData() {
    var groceryTag = new ProductTag { Value = "grocery" };
    // context.ProductTags.Add(groceryTag);
    var products = new List<Product>() {
        new Product { Name = "Cheese Forte Classico 180g", Tags = new List<ProductTag> { groceryTag }  },
        new Product { Name = "Cheese Forte Speciale 180g", Tags = new List<ProductTag> { groceryTag }  },
        new Product { Name = "Cheese Forte Superiore 180g", Tags = new List<ProductTag> { groceryTag }  },
    };
    context.Products.AddRange(products);
    // context.StoreProducts.AddRange(new[] {
    //     new StoreProduct { StoreId = 1, ProductId = 1, ApiStringId = "juust-forte-classico-26-valio-180-g" },
    //     new StoreProduct { StoreId = 1, ProductId = 2, ApiStringId = "juust-forte-speciale-valio-180-g" },
    //     new StoreProduct { StoreId = 1, ProductId = 3, ApiStringId = "juust-forte-superiore-26-valio-180-g" },
    // });
    context.SaveChanges();
}

//AddPrice();
void AddPrice() {
    var rand = new Random();
    var priceDelta = rand.Next(1, 10000) / 100M;
    var storeProduct = context.StoreProducts.ToList();
    var prices = new List<StoreProductPrice> {
        new StoreProductPrice { StoreProduct = storeProduct[0], Amount = 10M + priceDelta },
        new StoreProductPrice { StoreProduct = storeProduct[1], Amount = 20M + priceDelta },
        new StoreProductPrice { StoreProduct = storeProduct[2], Amount = 30M + priceDelta },
    };
    context.StoreProductPrices.AddRange(prices);
    context.SaveChanges();
}

//DeleteTable();
void DeleteTable() {
    context.StoreProductPrices.ExecuteDelete();
}

//UpdatePrices();
void UpdatePrices() {
    using var httpClient = new System.Net.Http.HttpClient();
    var remoteStore = new PriceMonitor.Core.RemoteStore.Service(httpClient, context);
    remoteStore.UpdatePricesAsync().Wait();
}

//ReadData();
void ReadData() {
    var result =
        context.StoreProductPrices
        .ToList();
}