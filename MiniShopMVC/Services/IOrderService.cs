using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;

namespace MiniShopMVC.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrdersAsync(OrderFilter filter);
    Task<Order> AddOrderAsync(OrderAddViewModel model);
    Task<Order?> GetByIdAsync(long id);
    Task<Order?> DeleteOrderAsync(long id);
    Task<Order?> UpdateOrderAsync(OrderUpdateViewModel model);
}