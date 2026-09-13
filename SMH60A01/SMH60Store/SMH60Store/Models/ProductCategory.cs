using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMH60Store.Models;

public partial class ProductCategory
{
    [Key] public int ProdCatId { get; set; }
    public string? ProdCat { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
