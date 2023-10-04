using System;
using TestAssignment.Domain.Entity;
using TestAssignment.Domain.ViewModels.Category;

namespace TestAssignment.Service.Interfaces
{
	public interface ICategoryService
	{
		Task<List<Category>> GetCategories();

		Task<Category> GetCategory(int id);

		Task<Category> CreateCategory(CategoryViewModel model);

		Task<bool> DeleteCategory(int id);

		Task<Category> EditCategory(int id, CategoryViewModel model);
	}
}

