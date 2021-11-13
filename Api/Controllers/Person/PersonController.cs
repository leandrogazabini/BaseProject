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
using static DllModels.Models.Util.DefaultResponses;
using DllModels.Models;
using System.Text.Json;
using Api.Bases;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace Api.Controllers
{
	//[Authorize]
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class CreatePersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public CreatePersonController(IPersonRepository _personRepository)
		{
			this.personRepository = _personRepository;
		}

		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpPost]
		public async Task<ActionResult> CreatePerson(NewPersonViewModel objNewPerson)
		{
			try
			{
				var map = new BusinessLogic.Mapping.PersonViewModelMapping();
				var person = map.MapToPerson(objNewPerson);
				var resultGet = personRepository.dbCreateOne(person);
				
				return StatusCode(StatusCodes.Status200OK, resultGet);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
			}
		}

	}

	//[Authorize]
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class EditPersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public EditPersonController(IPersonRepository _personRepository)
		{
			this.personRepository = _personRepository;
		}
		[AllowAnonymous]
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpPost]
		public async Task<ActionResult> EditPerson(PersonViewModel obj)
		{

			try
			{
				//var person = new Person(
				//	kindPerson: 1,
				//	alterDoc: obj.OfficialName,
				//	mainDoc: obj.OfficialName,
				//	name: obj.OfficialName,
				//	alterName: obj.OfficialName
				//	);
				var map = new BusinessLogic.Mapping.PersonViewModelMapping();
				Person person;
				person = map.MapToPerson(obj);

				var resultGet = personRepository.dbUpdateOne(person);
				//if (resultGet.ResponseStatus == ResponseStatus.Ok)
				return StatusCode(StatusCodes.Status200OK, resultGet);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error!");
			}
		}




	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class RequestPersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public RequestPersonController()
		{
			personRepository = new Person();
		}
		[AllowAnonymous]
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet("guid")]
		public ActionResult Response(string guid)
		{
			try
			{
				var resultGet = personRepository.dbReadOne(guid);
				var map = new BusinessLogic.Mapping.PersonViewModelMapping();
				var vmResult = map.MapToPersonVM((BusinessLogic.BLLs.Person)resultGet.ReferenceObject); ;
				//var resultPerson = new PersonViewModel() { Name = resultGet.};
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
}
