
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMH60Store.Models;

public class ProductCategoryController : Controller
{
    private readonly IStoreRepository<ProductCategory> _repo;

    public ProductCategoryController(IStoreRepository<ProductCategory> repo)
    {
        _repo = repo;
    }

    // GET: PRODUCTCATEGORYS
    public async Task<IActionResult> Index(string? search)    
    {
        return View(await _repo.GetList(search));
    }

    // GET: PRODUCTCATEGORYS/Details/5
    public async Task<IActionResult> Details(int? prodcatid)
    {
        if (prodcatid == null)
        {
            return NotFound();
        }

        var productcategory = await _repo.GetById(prodcatid);
        if (productcategory == null)
        {
            return NotFound();
        }

        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTCATEGORYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProdCatId,ProdCat,Products")] ProductCategory productcategory)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(productcategory);
            return RedirectToAction(nameof(Index));
        }
        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Edit/5
    public async Task<IActionResult> Edit(int? prodcatid)
    {
        if (prodcatid == null)
        {
            return NotFound();
        }

        var productcategory = await _repo.GetById(prodcatid);
        if (productcategory == null)
        {
            return NotFound();
        }
        return View(productcategory);
    }

    // POST: PRODUCTCATEGORYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? prodcatid, [Bind("ProdCatId,ProdCat,Products")] ProductCategory productcategory)
    {
        if (prodcatid != productcategory.ProdCatId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repo.Update(productcategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(productcategory.ProdCatId))
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
        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Delete/5
    public async Task<IActionResult> Delete(int? prodcatid)
    {
        if (prodcatid == null)
        {
            return NotFound();
        }

        var productcategory = await _repo.GetById(prodcatid);
        if (productcategory == null)
        {
            return NotFound();
        }

        return View(productcategory);
    }

    // POST: PRODUCTCATEGORYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? prodcatid)
    {
        var productcategory = await _repo.GetById(prodcatid);
        if (productcategory != null)
        {
            _repo.Delete(productcategory);
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ProductCategoryExists(int? prodcatid)
    {
        return _repo.GetById(prodcatid) != null;
    }
}
