using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMaterialUI.Components
{
	public partial class AdditionalProductInfo
	{
		[Parameter]
		public Product Product { get; set; }
		[Parameter]
		public int ReviewCount { get; set; }
		[Parameter]
		public int QuestionCount { get; set; }
	}
}
