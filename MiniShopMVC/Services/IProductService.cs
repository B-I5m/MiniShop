using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;

namespace MiniShopMVC.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync(ProductFilter filter);
    Task<Product> AddProductAsync(ProductAddViewModel model);
    Task<Product> DeleteProductAsync(long id);
    Task<Product?> GetByIdAsync(long id);
    Task<Product> UpdateProductAsync(ProductUpdateViewModel model);

}