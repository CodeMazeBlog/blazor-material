using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;

namespace BlazorMaterialUI.Components
{
	public partial class Charts
	{
		[Parameter]
		public string ProductName { get; set; }

		private bool _lineChartDisplayed = true;
		private List<ChartSeries> _lineChartSeries;
		private double[] _pieChartData;
		private string[] _chartLabels;

		private ChartOptions _lineChartOptions = new ChartOptions
		{
			YAxisLines = true
		};

		protected override void OnParametersSet()
		{
			var chartData = DataStorage.GetChartData(ProductName);
			_lineChartSeries = chartData.ChartData;
			_pieChartData = chartData.ChartData.Select(d => d.Data).First();
			_chartLabels = chartData.Labels;
		}

		private void SwitchChart() => _lineChartDisplayed = !_lineChartDisplayed;
	}
}
