using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlazorProducts.Server.Context.Configuration
{
	public class DeclarationConfiguration : IEntityTypeConfiguration<Declaration>
	{
		public void Configure(EntityTypeBuilder<Declaration> builder)
		{
			builder.HasData(
				new Declaration
				{
					Id = new Guid("13feebbc-ab65-4e37-aa39-fcc2ed5e5015"),
					Model = "Case & Skin for Samsung Galaxy G324 149 x 70.4 x 7.8 mm",
					CustomerRights = "All customer rights guaranteed under consumer protection law.",
					Origin = "USA",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				}
			);
		}
	}
}
