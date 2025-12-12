namespace MiniShopMVC.Models.Entities;

public class ProductOrder : BaseEntity
{
    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;
    
    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;
}