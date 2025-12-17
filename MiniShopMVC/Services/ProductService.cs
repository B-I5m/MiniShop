using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniShopMVC.Data;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;

namespace MiniShopMVC.Services
{
    public class ProductService(ApplicationDbContext context, IMapper mapper) : IProductService
    {
        public async Task<List<Product>> GetProductsAsync(ProductFilter filter)
        {
            var query = context.Products.Include(p => p.Category).AsQueryable();

            if (filter.Id.HasValue) query = query.Where(x => x.Id == filter.Id.Value);
            if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => x.Name.Contains(filter.Name));

            return await query.ToListAsync();
        }

        public async Task<Product> AddProductAsync(ProductAddViewModel model)
        {
            var product = mapper.Map<Product>(model);
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(long id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
                return null!;

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> GetByIdAsync(long id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProductAsync(ProductUpdateViewModel model)
        {
            var product = await context.Products.FindAsync(model.Id);
            if (product == null)
                return null!;

            mapper.Map(model, product);
            await context.SaveChangesAsync();

            return product;
        }

    }
    
}