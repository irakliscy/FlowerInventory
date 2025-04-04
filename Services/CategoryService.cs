﻿
using FlowerInventory.Models;

namespace FlowerInventory.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FlowerInventoryContext _context;  

       
        public CategoryService(FlowerInventoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();  
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);  
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);  
            _context.SaveChanges();  
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);  
            _context.SaveChanges();  
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);  
            if (category != null)
            {
                _context.Categories.Remove(category);  
                _context.SaveChanges();  
            }
        }
    }
}
