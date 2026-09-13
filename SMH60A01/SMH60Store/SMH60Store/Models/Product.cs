using System;
using System.Collections.Generic;

namespace SMH60Store.Models;

public partial class Product
{
    private int _productId;
    private int _prodCatId;
    private string? _description;
    private string? _manufacturer;
    private int _stock;
    private decimal? _buyPrice;
    private decimal? _sellPrice;
    private ProductCategory _prodCat = null!;

    public int ProductId
    {
        get => _productId;
        set => _productId = value;
    }

    public int ProdCatId
    {
        get => _prodCatId;
        set => _prodCatId = value;
    }

    public string? Description
    {
        get => _description;
        set => _description = value;
    }

    public string? Manufacturer
    {
        get => _manufacturer;
        set => _manufacturer = value;
    }

    public int Stock
    {
        get => _stock;
        set => _stock = value;
    }

    public decimal? BuyPrice
    {
        get => _buyPrice;
        set => _buyPrice = value;
    }

    public decimal? SellPrice
    {
        get => _sellPrice;
        set => _sellPrice = value;
    }

    public virtual ProductCategory ProdCat
    {
        get => _prodCat;
        set => _prodCat = value;
    }
}
