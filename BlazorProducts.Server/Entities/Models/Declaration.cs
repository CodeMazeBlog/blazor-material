using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class Declaration
	{
		public Guid Id { get; set; }
		public string Model { get; set; }
		public string Origin { get; set; }
		public string CustomerRights { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
