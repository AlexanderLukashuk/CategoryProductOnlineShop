using System;
using System.ComponentModel.DataAnnotations;

namespace TestAssignment.Domain.ViewModels.Category
{
	public class CategoryViewModel
	{
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Specify the Name")]
		[Display(Name = "Category name")]
		public string? Name { get; set; }
	}
}

