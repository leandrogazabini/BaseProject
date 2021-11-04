using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace Api.Bases
{
	/// <summary>
	/// If the endpoint is ok return Status 200 + Message: "Online:, date + time,"
	/// </summary>
	[ApiExplorerSettings(IgnoreApi = true)]
	[Authorize]
	public class AppControllerBase : ControllerBase
	{
		[HttpGet("IsOnline")]
		public async Task<ActionResult> IsOnline()
		{
			return StatusCode(StatusCodes.Status200OK, $"Online: {DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()}");
		}

	}
}
