using System;
using System.ComponentModel.DataAnnotations;

namespace TestAssignment.Domain.ViewModels.Product
{
	public class ProductViewModel
	{
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Specify the product name")]
		[Display(Name = "Product name")]
		public string? Name { get; set; }

		[Display(Name = "Description")]
		public string? Description { get; set; }

		[Required]
		[Display(Name = "Price")]
		public decimal Price { get; set; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
	}
}

