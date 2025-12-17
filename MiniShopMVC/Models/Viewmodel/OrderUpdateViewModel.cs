namespace MiniShopMVC.Models;

public class OrderUpdateViewModel
{
    public long Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
}