//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;

//namespace Api.Controllers
//{
//	[ApiExplorerSettings(IgnoreApi = false)]
//	[ApiController]
//	[Route("[controller]")]

//	public class ApiController : ControllerBase
//	{
//		[HttpGet]
//		public async Task<ActionResult> api()
//		{
//			return StatusCode(StatusCodes.Status200OK, $"ok: {DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()}");
//		}

//	}
//}
