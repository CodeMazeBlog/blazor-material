using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlazorProducts.Server.Context.Configuration
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasData(
				new Review
				{
					Id = new Guid("b4031733-83a6-4d7c-b995-a3a0c0a35c39"),
					Comment = "Great product. Fits my phone perfectly.",
					Rate = 5,
					User = "Tim Malock",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				},
				new Review
				{
					Id = new Guid("f43017fd-1a65-4ad1-8610-ec4154a21c87"),
					Comment = "I use it all the time. Excellent stuff.",
					Rate = 4,
					User = "Ana Swan",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				},
				new Review
				{
					Id = new Guid("b88bc5c2-660d-4604-ba92-69abf546e881"),
					Comment = "It could be better, I am not that satisfied.",
					Rate = 3,
					User = "John Mining",
					ProductId = new Guid("4E693871-788D-4DB4-89E5-DD7678DB975E")
				}
			);
		}
	}
}
