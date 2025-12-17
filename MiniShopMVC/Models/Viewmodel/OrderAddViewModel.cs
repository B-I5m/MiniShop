namespace MiniShopMVC.Models;

public class OrderAddViewModel
{
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public List<OrderProductItemViewModel> Products { get; set; } = new();
}