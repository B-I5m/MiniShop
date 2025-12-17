namespace MiniShopMVC.Models
{
    public class ProductAddViewModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
    }
}
