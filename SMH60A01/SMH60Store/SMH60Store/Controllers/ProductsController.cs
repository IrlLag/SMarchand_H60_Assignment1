using Microsoft.AspNetCore.Mvc;
using SMH60Store.Models;

public class ProductsController : Controller
{
    private readonly IStoreRepository<Product> _repo;

    public ProductsController(IStoreRepository<Product> repository)
    {
        _repo = repository;
    }

    // GET: PRODUCTS
    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetList());
    }

    // GET: PRODUCTS/Details/5
    public async Task<IActionResult> Details(int? productid)
    {
        if (productid == null) return NotFound();

        var product = await _repo.GetById(productid);


        if (product == null) return NotFound();

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
    public async Task<IActionResult> Create(
        [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")]
        Product product)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: PRODUCTS/UpdateStock/5
    public async Task<IActionResult> UpdateStock(int? productid)
    {
        if (productid == null) return NotFound();
        ViewData["ProductId"] = productid;

        var product = await _repo.GetById(productid);
        if (product == null) return NotFound();
        return View();
    }

    // POST: PRODUCTS/UpdateStock/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStock(int? productid, int? stock)
    {
        if (productid is null)
        {
            return NotFound();
        }

        if (stock is null)
        {
            ViewData["ErrorMessage"] += "There is no stock value in the field";
            return View();
        }
        else
        {
            var product = await _repo.GetById(productid);
            if (product is null)
            {
                return NotFound();
            }

            if( product.Stock + (int)stock < 0 )
            {
                ViewData["ErrorMessage"] += "The final stock value cannot be negative";
                return View();
            }

            product.Stock += (int)stock;
            _repo.Update(product);

            return RedirectToAction(nameof(Index));
        }
    }

    // GET: PRODUCTS/ChangeBuySellPrice/5
    public async Task<IActionResult> UpdateBuySellPrice(int? productid)
    {
        if (productid == null) return NotFound();

        var product = await _repo.GetById(productid);
        if (product == null) return NotFound();
        return View(product);
    }

    // POST: PRODUCTS/ChangeBuySellPrice/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateBuySellPrice(int? productid,
        [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")]
        Product product)
    {
        if (productid != product.ProductId) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _repo.Update(product);
            }
            catch
            {
                if (!ProductExists(product.ProductId)) return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    // GET: PRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? productid)
    {
        if (productid == null) return NotFound();

        var product = await _repo.GetById(productid);
        if (product == null) return NotFound();

        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? productid)
    {
        var product = await _repo.GetById(productid);
        if (product != null) _repo.Delete(product);

        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int? productid)
    {
        return _repo.GetList().Result.Any(e => e.ProductId == productid);
    }
}