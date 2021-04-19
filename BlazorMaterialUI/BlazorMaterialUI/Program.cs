using BlazorMaterialUI.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMaterialUI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient 
			{ 
				BaseAddress = new Uri("https://localhost:5011/api/") 
			});

			builder.Services.AddMudServices(config =>
			{
				config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
				config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
				config.SnackbarConfiguration.ShowCloseIcon = true;
				config.SnackbarConfiguration.MaxDisplayedSnackbars = 1;
			});

			builder.Services.AddScoped<IHttpClientRepository, HttpClientRepository>();

			await builder.Build().RunAsync();
		}
	}
}
