using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
	public class ErrorMiddleware
	{
		private readonly RequestDelegate _next;
		public ErrorMiddleware(RequestDelegate next)
		{
			this._next = next;
		}
		public async Task Invoke(HttpContext httpContext)
		{
			try
			{

				await _next(httpContext);
				if (httpContext.Response.StatusCode == 400)
				{
					//httpContext.Response.Clear();
					await httpContext.Response.WriteAsync("aaaaaa");

				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
