using BlazorMaterialUI.Features;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestParameters;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMaterialUI.HttpRepository
{
	public class HttpClientRepository : IHttpClientRepository
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _options;

		public HttpClientRepository(HttpClient client)
		{
			_client = client;
			_options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		}

		public async Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters)
		{
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = productParameters.PageNumber.ToString(),
				["pageSize"] = productParameters.PageSize.ToString(),
				["searchTerm"] = productParameters.SearchTerm ?? "",
				["orderBy"] = productParameters.OrderBy ?? "name"
			};

			using (var response = await _client.GetAsync(QueryHelpers.AddQueryString("products", queryStringParam)))
			{
				response.EnsureSuccessStatusCode();

				var metaData = JsonSerializer
					.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options);

				var stream = await response.Content.ReadAsStreamAsync();

				var pagingResponse = new PagingResponse<Product>
				{
					Items = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _options),
					MetaData = metaData
				};

				return pagingResponse;
			}
		}

		public async Task<Product> GetProduct(Guid id)
		{
			var uri = $"products/{id}";

			using (var response = await _client.GetAsync(uri))
			{
				response.EnsureSuccessStatusCode();

				var stream = await response.Content.ReadAsStreamAsync();

				var product = await JsonSerializer.DeserializeAsync<Product>(stream, _options);

				return product;
			}
		}

		public async Task CreateProduct(Product product)
			=> await _client.PostAsJsonAsync("products", product);

		public async Task<string> UploadImage(MultipartFormDataContent content)
		{
			var postResult = await _client.PostAsync("upload", content);
			var postContent = await postResult.Content.ReadAsStringAsync();

			var imgUrl = Path.Combine("https://localhost:5011/", postContent);
			
			return imgUrl;
		}
	}
}
