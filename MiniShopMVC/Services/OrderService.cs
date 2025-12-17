using Microsoft.EntityFrameworkCore;
using MiniShopMVC.Data;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;

namespace MiniShopMVC.Services;

public class OrderService(ApplicationDbContext context) : IOrderService
{
    public async Task<List<Order>> GetOrdersAsync(OrderFilter filter)
    {
        var query = context.Orders
            .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
            .AsQueryable();

        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        return await query.ToListAsync();
    }

    public async Task<Order> AddOrderAsync(OrderAddViewModel model)
    {
        var order = new Order
        {
            CustomerName = model.CustomerName,
            CustomerPhone = model.CustomerPhone,
            OrderDate = DateTime.UtcNow,
            ProductOrders = new List<ProductOrder>()
        };

        foreach (var item in model.Products)
        {
            order.ProductOrders.Add(new ProductOrder
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        return order;
    }


    public async Task<Order?> GetByIdAsync(long id)
    {
        return await context.Orders
            .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order?> DeleteOrderAsync(long id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order == null) return null;

        context.Orders.Remove(order);
        await context.SaveChangesAsync();

        return order;
    }

    public async Task<Order?> UpdateOrderAsync(OrderUpdateViewModel model)
    {
        var order = await context.Orders.FindAsync(model.Id);
        if (order == null) return null;

        order.CustomerName = model.CustomerName;
        order.CustomerPhone = model.CustomerPhone;

        await context.SaveChangesAsync();
        return order;
    }
}
