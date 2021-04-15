using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class Review
	{
		public Guid Id { get; set; }
		public string User { get; set; }
		public string Comment { get; set; }
		public int Rate { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
