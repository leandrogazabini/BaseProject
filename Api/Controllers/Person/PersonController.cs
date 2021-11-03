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
using Api.Bases;
using Api.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class CreatePersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public CreatePersonController(IPersonRepository _personRepository)
		{
			this.personRepository = _personRepository;
		}

		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpPost]
		public async Task<ActionResult> SavePerson(PersonViewModel obj)
		{
			//var result = StatusCode(204);
			try
			{
				var person = new Person() { OfficialName = obj.Name };
				var resultGet = personRepository.dbCreate(person);
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
	[Authorize]
	[Route("api/[controller]")]
	public class RequestPersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public RequestPersonController()
		{
			personRepository = new Person();
		}
		
		[ApiExplorerSettings(IgnoreApi = false)]
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
