using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SMH60Store.Models;

public partial class Product
{
    public static int CurrentProductId { get; set; } = 0;
    public int ProductId { get; set; }

    public int ProdCatId { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public int Stock { get; set; }

    public decimal? BuyPrice { get; set; }

    public decimal? SellPrice { get; set; }

    public virtual ProductCategory ProdCat { get; set; } = null!;

    public Product()
    {
        ProductId = ++CurrentProductId;
    }
    public Product(int id, string description, string manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductId = id;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }
    public Product( string description, string manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductId = ++CurrentProductId;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }
}
