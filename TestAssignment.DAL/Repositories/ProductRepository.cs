using System;
using TestAssignment.DAL.Interfaces;
using TestAssignment.Domain.Entity;

namespace TestAssignment.DAL.Repositories
{
	public class ProductRepository : IBaseRepository<Product>
	{
        private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
            _context = context;
		}

        public async Task Create(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public async Task<Product> Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

