using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BLLs;
using BusinessLogic.Interfaces;
using DllModels.Models.Util;
using Microsoft.AspNetCore.Http;
using static DllModels.Models.Util.Responses;
using DllModels.Models;
using System.Text.Json;


namespace Api.Controllers
{
	[ApiExplorerSettings(IgnoreApi = false)]
	[ApiController]
	[Route("/")]

	public class StatusController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult> api()
		{
			return StatusCode(StatusCodes.Status200OK, $"ok: {DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()}");
		}

	}

}
