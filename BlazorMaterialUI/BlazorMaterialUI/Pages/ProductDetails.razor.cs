using BlazorMaterialUI.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMaterialUI.Pages
{
	public partial class ProductDetails
	{
		public Product Product { get; set; } = new Product
		{
			Reviews = new List<Review>(),
			Declaration = new Declaration(),
			QAs = new List<QA>()
		};

		[Inject]
		public IHttpClientRepository Repository { get; set; }

		[Parameter]
		public Guid ProductId { get; set; }

		private int _currentRating;
		private int _reviewCount;
		private int _questionCount;

		protected async override Task OnInitializedAsync()
		{
			Product = await Repository.GetProduct(ProductId);
			_reviewCount = Product.Reviews.Count;
			_questionCount = Product.QAs.Count;
			_currentRating = CalculateRating();
		}

		private int CalculateRating()
		{
			var rating = Product.Reviews.Any() ? Product.Reviews.Average(r => r.Rate) : 0;
			return Convert.ToInt32(Math.Round(rating));
		}

		private void RatingValueChanged(int value) => 
			Console.WriteLine($"The product is rated with {value} thumbs.");
	}
}
