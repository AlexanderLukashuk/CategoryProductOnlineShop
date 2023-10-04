using System;
using Microsoft.EntityFrameworkCore;
using TestAssignment.DAL.Interfaces;
using TestAssignment.Domain.Entity;
using TestAssignment.Domain.ViewModels.Category;
using TestAssignment.Service.Interfaces;

namespace TestAssignment.Service.Implementations
{
	public class CategoryService : ICategoryService
	{
        private readonly IBaseRepository<Category> _categoryRepository;

		public CategoryService(IBaseRepository<Category> categoryRepository)
		{
            _categoryRepository = categoryRepository;
		}

        public async Task<Category> CreateCategory(CategoryViewModel model)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (existingCategory != null)
                {
                    return existingCategory;
                }

                var category = new Category
                {
                    Name = model.Name
                };

                await _categoryRepository.Create(category);

                return category;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }

            await _categoryRepository.Delete(category);

            return true;
        }

        public async Task<Category> EditCategory(int id, CategoryViewModel model)
        {
            var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            category.Name = model.Name;

            await _categoryRepository.Update(category);

            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetAll().ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

