using BlazorMaterialUI.HttpRepository;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorMaterialUI.Pages
{
	public partial class FetchData
	{
		private MudTable<Product> _table;
		private ProductParameters _productParameters = new ProductParameters();
		private readonly int[] _pageSizeOption = { 4, 6, 10 };
		private string _searchTerm;
		private Timer _timer;

		[Inject]
		public IHttpClientRepository Repository { get; set; }

		private async Task<TableData<Product>> GetServerData(TableState state)
		{
			_productParameters.PageSize = state.PageSize;
			_productParameters.PageNumber = state.Page + 1;

			_productParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
				state.SortLabel + " desc" :
				state.SortLabel;
		
			var response = await Repository.GetProducts(_productParameters);

			return new TableData<Product>
			{
				Items = response.Items,
				TotalItems = response.MetaData.TotalCount
			};
		}

		private void OnSearch()
		{
			if (_timer != null)
				_timer.Dispose();

			_timer = new Timer(OnTimerElapsed, null, 500, 0);
		}

		private void OnTimerElapsed(object sender)
		{
			_timer.Dispose();
			_productParameters.SearchTerm = _searchTerm;
			_table.ReloadServerData();
		}
	}
}
