using System;
using System.Collections.Generic;

namespace SMH60Store.Models;

public partial class ProductCategory
{
    private int _prodCatId;
    private string? _prodCat = null;
    private ICollection<Product> _products = new List<Product>();

    public int ProdCatID
    {
        get => _prodCatId;
        set => _prodCatId = value;
    }

    public string ProdCat
    {
        get => _prodCat;
        set => _prodCat = value;
    }

    public virtual ICollection<Product> Products
    {
        get => _products;
        set => _products = value;
    }
}
