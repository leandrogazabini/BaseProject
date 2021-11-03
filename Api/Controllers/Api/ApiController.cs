﻿using Microsoft.AspNetCore.Mvc;
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
using Api.Bases;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
	/// <summary>
	/// If the endpoint is ok return 200 + Messagem: "Ok, date and time,"
	/// </summary>
	[AllowAnonymous]
	[ApiController]
	[Route("/")]
	public class StatusController : AppControllerBase
	{
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet]
		public async Task<ActionResult> Response()
		{
			return StatusCode(StatusCodes.Status200OK, $"Visit: thisurl + /swagger/index.html");
		}

	}

}
