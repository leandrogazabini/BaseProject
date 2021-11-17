using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BLLs;
using BusinessLogic.Interfaces;
//using DllModels.Models.Util;
using Microsoft.AspNetCore.Http;
//using static DllModels.Models.Util.DefaultResponses;
using DllModels.Models;
using System.Text.Json;
using Api.Bases;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
//using DefaultResponses = BusinessLogic.Default.Responses.DefaultResponses;


namespace Api.Controllers
{
	/// <summary>
	/// If the endpoint is ok return 200 + Messagem: "Ok, date and time,"
	/// </summary>
	//[ApiExplorerSettings(GroupName = "Status")]
	[AllowAnonymous]
	[ApiController]
	[Route("/Status")]
	public class StatusController : AppControllerBase
	{
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet]
		public async Task<ActionResult> Response()
		{
			return StatusCode(StatusCodes.Status200OK, $"Visit: thisurl + /swagger/index.html");
		}

	}

	//[ApiExplorerSettings(GroupName = "Culture")]
	[AllowAnonymous]
	[ApiController]
	[Route("/SetCulture")]
	public class SetCultureController : AppControllerBase
	{
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpPost]
		public async Task<ActionResult> SetCulture(int value)
		{
			try
			{
				var result = Startup.AppSettings._cultureSetting.SetCurrentCulture(value);
				if (result) return StatusCode(StatusCodes.Status200OK,Startup.AppSettings._cultureSetting.GetCurrentCulture());
				else return StatusCode(StatusCodes.Status400BadRequest);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}


	//[ApiExplorerSettings(GroupName = "Culture")]
	[AllowAnonymous]
	[ApiController]
	[Route("/GetActualCulture")]
	public class GetActualCultureController : AppControllerBase
	{

		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet]
		public async Task<ActionResult> ReturnActualCulture()
		{
			var culture = Startup.AppSettings._cultureSetting.GetCurrentCulture();
			return StatusCode(StatusCodes.Status200OK, $"{culture}");
		}

	}


	[ApiExplorerSettings(GroupName = "Culture")]
	[AllowAnonymous]
	[ApiController]
	[Route("/SupportedCultures")]
	public class SupportedCulturesController : AppControllerBase
	{

		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet]
		public async Task<ActionResult> ReturnSupportedCultures()
		{
			var cultures = Startup.AppSettings._cultureSetting.ListAllSupportedCulture();
			var result = JsonConvert.SerializeObject(cultures);
			return StatusCode(StatusCodes.Status200OK, result);
		}

	}

	//[AllowAnonymous]
	//[ApiController]
	//[Route("/")]
	//public class GetLanguageController : AppControllerBase
	//{
	//	[ApiExplorerSettings(IgnoreApi = false)]
	//	[HttpGet]
	//	public async Task<ActionResult> ReturnCulture(string value = "")
	//	{
	//		var culture = Startup.AppSettings._cultureSetting.GetCurrentCulture();
	//		return StatusCode(StatusCodes.Status200OK,$"{culture}");
	//	}
	//}


}






