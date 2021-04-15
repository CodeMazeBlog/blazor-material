using BlazorProducts.Server.Context.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Context
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions options)
			:base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new QAConfiguration());
			modelBuilder.ApplyConfiguration(new DeclarationConfiguration());
			modelBuilder.ApplyConfiguration(new ReviewConfiguration());
		}

		public DbSet<Product> Products { get; set; }
	}
}
