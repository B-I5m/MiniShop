using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniShopMVC.Models;

namespace MiniShopMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult ContactUs()
    {
        var ourContact = new ContactViewModel
        {
            Phone = "+1-800-123-4567",
            Email = "examle@mail.ru",
            Address = "123 Main St, Anytown, USA"
        };
        
        return View(ourContact);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}