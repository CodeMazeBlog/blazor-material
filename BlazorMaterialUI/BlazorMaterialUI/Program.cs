using BlazorMaterialUI.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

			builder.Services.AddMudServices();
			builder.Services.AddScoped<IHttpClientRepository, HttpClientRepository>();

			await builder.Build().RunAsync();
		}
	}
}
