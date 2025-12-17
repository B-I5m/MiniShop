using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Filters;
using MiniShopMVC.Services;

namespace MiniShopMVC.Controllers;

public class OrderController(
    IOrderService orderService,
    IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var orders = await orderService.GetOrdersAsync(new OrderFilter());
        return View(orders);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Products = (await productService.GetProductsAsync(new ProductFilter()))
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

        var model = new OrderAddViewModel
        {
            Products = new List<OrderProductItemViewModel>
            {
                new()
            }
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Create(OrderAddViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await orderService.AddOrderAsync(model);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        await orderService.DeleteOrderAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
}