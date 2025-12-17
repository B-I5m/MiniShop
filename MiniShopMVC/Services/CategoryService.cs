using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniShopMVC.Data;
using MiniShopMVC.Models;
using MiniShopMVC.Models.Entities;
using MiniShopMVC.Models.Filters;



namespace MiniShopMVC.Services;

public class CategoryService(ApplicationDbContext context, IMapper mapper) : ICategoryService
{
    public async Task<List<Category>> GetCategoriesAsync(CategoryFilter f)
    {
        var query = context.Categories
            .AsQueryable();

        if (f.Id.HasValue) query = query.Where(x => x.Id == f.Id.Value);
        if (!string.IsNullOrEmpty(f.Name)) query = query.Where(x => x.Name.Contains(f.Name));
         
        return await query.ToListAsync();
    }

    public async Task<Category> AddCategoryAsync(CategoryAddViewModel model)
    {
        var category = mapper.Map<Category>(model);
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }
    public async Task<Category> DeleteCategoryAsync(long id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
            return null;

        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return category;
    }
    public async Task<Category?> GetByIdAsync(long id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<Category> UpdateCategoryAsync(CategoryUpdateViewModel model)
    {
        var category = await context.Categories.FindAsync(model.Id);
        if (category == null)
            return null!;

        mapper.Map(model, category);
        await context.SaveChangesAsync();

        return category;
    }

}