using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
	public class QA
	{
		public Guid Id { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
		public string User { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }
	}
}
