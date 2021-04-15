using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlazorProducts.Server.Context.Configuration
{
	public class QAConfiguration : IEntityTypeConfiguration<QA>
	{
		public void Configure(EntityTypeBuilder<QA> builder)
		{
			builder.HasData(
				new QA
				{
					Id = new Guid("94402f9d-f280-4a7d-9c95-13e430065cee"),
					Question = "Is there a guarantee for this product",
					Answer = "Hello Mick. Yes, there is a two year guarantee for it.",
					User = "Mick Simons",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				},
				new QA
				{
					Id = new Guid("06579037-943b-4ce5-8dd6-39f34ad49329"),
					Question = "How can I get this product",
					Answer = "Hello Brigit. You can order it online on our web shop.",
					User = "Brigit Fansey",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				}
			);
		}
	}
}
