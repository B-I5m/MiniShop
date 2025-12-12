namespace MiniShopMVC.Models.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    
    public ICollection<ProductOrder> ProductOrders { get; set; } = null!;
}