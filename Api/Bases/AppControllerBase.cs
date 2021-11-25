using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DefaultResponses = BusinessLogic.Default.ResponsesMessages.DefaultResponses;


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

		public ObjectResult ReturnStatusCodeAndObjectResponse(Object objSent)
		{
			if (objSent.GetType() == typeof(DefaultResponses.Response))
			{
				var response = (DefaultResponses.Response)objSent;
				switch (response.Status)
				{
					case true:
						return StatusCode(StatusCodes.Status200OK, objSent);
					case false:
						return StatusCode(StatusCodes.Status400BadRequest, objSent);
				}

			}
			else if (objSent.GetType() == typeof(Exception))
			{
				return StatusCode(StatusCodes.Status400BadRequest, @":(");
			}
			else
			{
				return StatusCode(StatusCodes.Status500InternalServerError, @"");
			}


			

		}
	}

}
