using System;
using System.Collections.Generic;

namespace SMH60Store.Models;

public partial class Product
{
    public static int CurrentProductId = 0;
    public int ProductId
    {
        get;
        set;
    }

    public int ProdCatId
    {
        get;
        set;
    }

    public string? Description
    {
        get;
        set;
    }

    public string? Manufacturer
    {
        get;
        set;
    }

    public int Stock
    {
        get;
        set;
    }

    public decimal? BuyPrice
    {
        get;
        set;
    }

    public decimal? SellPrice
    {
        get;
        set;
    }

    public virtual ProductCategory ProdCat
    {
        get;
        set;
    }

    public Product()
    {

    }
    public Product(int productId)
    {
        ProductId = productId;
    }
    public Product(int productId, int prodCatId, string? description, string? manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductId = productId;
        ProdCatId = prodCatId;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }
    public Product( int prodCatId, string? description, string? manufacturer, int stock, decimal? buyPrice, decimal? sellPrice)
    {
        ProductId = CurrentProductId++;
        ProdCatId = prodCatId;
        Description = description;
        Manufacturer = manufacturer;
        Stock = stock;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
    }
}
