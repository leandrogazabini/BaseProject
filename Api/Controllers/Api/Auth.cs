using Api.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.Api
{
	/// <summary>
	/// If the endpoint is ok return 200 + Messagem: "Ok, date and time,"
	/// </summary>
	[ApiController]
	[AllowAnonymous]
	[Route("/auth")]
	public class AuthController : AppControllerBase
	{
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpPost]
		public async Task<ActionResult> Login(string username, string password)
		{
			var AuthService = new AuthenticationService();
			var result = AuthService.Authenticate(username, password,60);
			return StatusCode(StatusCodes.Status200OK, result);
		}

	}
}
