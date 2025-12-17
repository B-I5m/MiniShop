namespace MiniShopMVC.Models;

public class ProductUpdateViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
