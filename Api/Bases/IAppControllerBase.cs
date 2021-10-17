using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Bases
{
	interface IAppControllerBase
	{
		/// <summary>
		/// Return the endpoint status.
		/// </summary>
		/// <returns></returns>
		public Task<ActionResult> IsOnline();
	}
}
