using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Bases
{
	public class AppControllerBase : ControllerBase, IAppControllerBase
	{
		public virtual async Task<ActionResult> IsOnline()
		{
			return StatusCode(StatusCodes.Status200OK, $"ok: {DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()}");
		}
	}
}
