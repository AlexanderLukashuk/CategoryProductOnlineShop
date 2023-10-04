using System;
using Microsoft.EntityFrameworkCore;
using TestAssignment.Domain.Entity;

namespace TestAssignment.DAL
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }
	}
}

