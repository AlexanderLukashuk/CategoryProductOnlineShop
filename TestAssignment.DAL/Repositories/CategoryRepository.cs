using System;
using TestAssignment.DAL.Interfaces;
using TestAssignment.Domain.Entity;

namespace TestAssignment.DAL.Repositories
{
	public class CategoryRepository : IBaseRepository<Category>
	{
        private readonly ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context)
		{
            _context = context;
		}

        public async Task Create(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public async Task<Category> Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

