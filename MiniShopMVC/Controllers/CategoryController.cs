using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class CategoryController(ICategoryService service): Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await service.GetCategoriesAsync(new CategoryFilter());
        return View(categories);
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryAddViewModel model)
    {
        var category = await service.AddCategoryAsync(model);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        var category = await service.DeleteCategoryAsync(id);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(long id)
    {
        var category = await service.GetByIdAsync(id);
        if (category == null) return NotFound();

        return View(new CategoryUpdateViewModel
        {
            Id = category.Id,
            Name = category.Name
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryUpdateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await service.UpdateCategoryAsync(model);
        return RedirectToAction("Index");
    }

}