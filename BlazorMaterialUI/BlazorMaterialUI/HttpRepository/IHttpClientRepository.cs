using BlazorMaterialUI.Features;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMaterialUI.HttpRepository
{
	public interface IHttpClientRepository
	{
		Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
		Task<Product> GetProduct(Guid id);
	}
}
