using BlazorMaterialUI.HttpRepository;
using BlazorMaterialUI.Shared;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace BlazorMaterialUI.Pages
{
	public partial class CreateProduct
	{
		private Product _product = new Product();
		private DateTime? _date = DateTime.Today;

		[Inject]
		public IHttpClientRepository Repository { get; set; }
		[Inject]
		public IDialogService Dialog { get; set; }
		[Inject]
		public NavigationManager NavManager { get; set; }

		private async Task Create()
		{
			_product.ManufactureDate = (DateTime)_date;
			await Repository.CreateProduct(_product);
			await ExecuteDialog();
		}

		private async Task ExecuteDialog()
		{
			var parameters = new DialogParameters
			{
				{ "Content", "You have successfully created a new product." },
				{ "ButtonColor", Color.Primary },
				{ "ButtonText", "OK" }
			};

			var dialog = Dialog.Show<DialogNotification>("Success", parameters);

			var result = await dialog.Result;
			if(!result.Cancelled)
			{
				bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
				if (shouldNavigate)
					NavManager.NavigateTo("/fetchdata");
			}
		}

		private void SetImgUrl(string imgUrl) => _product.ImageUrl = imgUrl;
	}
}
