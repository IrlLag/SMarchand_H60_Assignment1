using Microsoft.AspNetCore.Mvc;
using SMH60Store.Models;
using System.Diagnostics;
public class ProductsController : Controller
{
    private readonly H60AssignmentDbSmContext _context;
    Product _product = new Product();

    public ProductsController(H60AssignmentDbSmContext context, Product product)
    {
        _context = context;
        _product = product;
    }

    // GET: PRODUCTS
    public async Task<IActionResult> Index()    
    {
        
        return View(await _product.GetProducts(_context));
    }

    // GET: PRODUCTS/Details/5
    public async Task<IActionResult> Details(int? productid)
    {
        
        if (productid == null)
        {
            return NotFound();
        }

        var product = _product.GetProductById(_context, productid);


        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: PRODUCTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")] Product product)
    {
        if (ModelState.IsValid)
        {
            _product.AddProduct(_context, product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Edit/5
    public async Task<IActionResult> Edit(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = await _product.GetProductById(_context, productid);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: PRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? productid, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")] Product product)
    {
        if (productid != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _product.UpdateProduct(_context, product);
            }
            catch
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = await _product.GetProductById(_context, productid);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? productid)
    {
        var product = await _product.GetProductById(_context, productid);
        if (product != null)
        {
            _product.DeleteProduct(_context, product);
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int? productid)
    {
        return _product.GetProducts(_context).Result.Any(e => e.ProductId == productid);
    }
}
