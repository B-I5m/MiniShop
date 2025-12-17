using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class ProductController(IProductService service, ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = await service.GetProductsAsync(new ProductFilter());
        return View(products);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
        ViewBag.Categories = categoryService.GetCategoriesAsync(new CategoryFilter())
            .Result
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();
        return View();
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductAddViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = categoryService.GetCategoriesAsync(new CategoryFilter())
                .Result
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
            return View(model);
        }

        await service.AddProductAsync(model);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        await service.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(long id)
    {
        var product = await service.GetByIdAsync(id);
        if (product == null) return NotFound();

        ViewBag.Categories = (await categoryService.GetCategoriesAsync(new CategoryFilter()))
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

        return View(new ProductUpdateViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductUpdateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await service.UpdateProductAsync(model);
        return RedirectToAction("Index");
    }

}