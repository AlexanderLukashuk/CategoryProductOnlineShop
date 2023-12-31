﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAssignment.Domain.Entity
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		public string? Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }

		public Category? Category { get; set; }
	}
}

