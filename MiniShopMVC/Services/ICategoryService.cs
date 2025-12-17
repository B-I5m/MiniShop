using MiniShopMVC.Models;
 using MiniShopMVC.Models.Entities;
 using MiniShopMVC.Models.Filters;


 namespace MiniShopMVC.Services;
 
 public interface ICategoryService
 {
     Task<List<Category>> GetCategoriesAsync(CategoryFilter f);
     Task<Category> AddCategoryAsync(CategoryAddViewModel model);
     Task<Category>DeleteCategoryAsync(long id);
     Task<Category> UpdateCategoryAsync(CategoryUpdateViewModel model);
     Task<Category?> GetByIdAsync(long id);

 
 }