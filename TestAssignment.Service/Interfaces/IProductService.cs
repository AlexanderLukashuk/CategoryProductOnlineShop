using System;
using TestAssignment.Domain.Entity;
using TestAssignment.Domain.ViewModels.Product;

namespace TestAssignment.Service.Interfaces
{
	public interface IProductService
	{
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(int id);

        Task<Product> CreateProduct(ProductViewModel model);

        Task<bool> DeleteProduct(int id);

        Task<Product> EditProduct(int id, ProductViewModel model);
    }
}

