namespace MiniShopMVC.Models.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public ICollection<ProductOrder> ProductOrders { get; set; } = null!;
}