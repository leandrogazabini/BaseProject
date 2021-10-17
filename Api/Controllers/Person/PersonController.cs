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
	[ApiController]
	[Route("api/[controller]")]
	public class CreatePersonController : ControllerBase
	{
		private readonly Person personRepository;
		public CreatePersonController()
		{
			this.personRepository = new Person();
		}

		[HttpPost]
		public async Task<ActionResult> SavePerson(Person obj)
		{
			//var result = StatusCode(204);
			try
			{
				var resultGet = personRepository.dbCreate(obj);
				//if (resultGet.ResponseStatus == ResponseStatus.Ok)
				return StatusCode(StatusCodes.Status200OK, resultGet);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
			}
		}

	}


	[ApiController]
	[Route("api/[controller]")]
	public class RequestPersonController : Controller
	{
		private readonly IPersonRepository personRepository;
		public RequestPersonController()
		{
			personRepository = new Person();
		}

		[HttpGet("guid")]
		public ActionResult Response(string guid)
		{
			try
			{
				var resultGet = personRepository.dbRead(guid);
				//if (resultGet.ResponseStatus == ResponseStatus.Ok)
				return StatusCode(StatusCodes.Status200OK, resultGet);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
			}
		}


	}
}
