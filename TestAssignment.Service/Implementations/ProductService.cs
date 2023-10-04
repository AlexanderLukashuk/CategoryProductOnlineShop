using System;
using Microsoft.EntityFrameworkCore;
using TestAssignment.DAL.Interfaces;
using TestAssignment.Domain.Entity;
using TestAssignment.Domain.ViewModels.Product;
using TestAssignment.Service.Interfaces;

namespace TestAssignment.Service.Implementations
{
	public class ProductService : IProductService
	{
        private readonly IBaseRepository<Product> _productRepository;

		public ProductService(IBaseRepository<Product> productRepository)
		{
            _productRepository = productRepository;
		}

        public async Task<Product> CreateProduct(ProductViewModel model)
        {
            var existingProduct = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == model.Id);

            if (existingProduct != null)
            {
                return existingProduct;
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            await _productRepository.Create(product);

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            await _productRepository.Delete(product);

            return true;
        }

        public async Task<Product> EditProduct(int id, ProductViewModel model)
        {
            var product = await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            await _productRepository.Update(product);

            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetAll().ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

