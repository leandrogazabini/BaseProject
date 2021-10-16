using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
	public class ErrorMiddleware : ControllerBase
	{
		private RequestDelegate _next;
		public ErrorMiddleware(RequestDelegate next)
		{
			this._next = next;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				//try { context.Request.EnableBuffering(); } catch { }
				await _next(context);
			}
			catch (Exception ex)
			{

			}
		}
	}


}
