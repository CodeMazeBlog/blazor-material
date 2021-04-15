using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Supplier { get; set; }
		public double Price { get; set; }
		public string ImageUrl { get; set; }
		public DateTime ManufactureDate { get; set; }

		public ICollection<Review> Reviews { get; set; }
		public ICollection<QA> QAs { get; set; }
		public Declaration Declaration { get; set; }
	}
}
