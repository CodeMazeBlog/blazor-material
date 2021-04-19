using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
	public class Product
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Supplier is requied.")]
		public string Supplier { get; set; }
		
		[Required(ErrorMessage = "Price is required.")]
		[Range(5, 1000, ErrorMessage = "Price must be between 5 and 1000.")]
		public double Price { get; set; }

		public string ImageUrl { get; set; }
		public DateTime ManufactureDate { get; set; }

		public ICollection<Review> Reviews { get; set; }
		public ICollection<QA> QAs { get; set; }
		public Declaration Declaration { get; set; }
	}
}
