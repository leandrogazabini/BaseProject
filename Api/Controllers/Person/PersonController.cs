using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.BLLs;
using BusinessLogic.Interfaces;
//using DllModels.Models.Util;
using Microsoft.AspNetCore.Http;
//using static DllModels.Models.Util.DefaultResponses;
using DllModels.Models;
using System.Text.Json;
using Api.Bases;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic;
using DefaultResponses = BusinessLogic.Default.ResponsesMessages.DefaultResponses;


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
				var map = new BusinessLogic.Mapping.PersonMapping();
				var person = map._mapper.Map<NewPersonViewModel, BusinessLogic.BLLs.Person>(objNewPerson);

				var resultGet = personRepository.dbCreateOne(person);

				var result = map._mapper.Map<BusinessLogic.BLLs.Person, PersonViewModel>((Person)resultGet.ReferenceObject);
				resultGet.SetReferenceObject<PersonViewModel>(result);
				
				return ReturnStatusCodeAndObjectResponse(resultGet);
				//return StatusCode(StatusCodes.Status200OK, resultGet);
			}
			catch (Exception ex)
			{
				return ReturnStatusCodeAndObjectResponse(ex);
				//return StatusCode(StatusCodes.Status500InternalServerError);
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
			
				var map = new BusinessLogic.Mapping.PersonMapping();
				Person person;
				person = map._mapper.Map<PersonViewModel, BusinessLogic.BLLs.Person>(obj);
				var resultGet = personRepository.dbUpdateOne(person);
				PersonViewModel personVM = map._mapper.Map<BusinessLogic.BLLs.Person, PersonViewModel>((BusinessLogic.BLLs.Person)resultGet.ReferenceObject);
				resultGet.SetReferenceObject<PersonViewModel>(personVM);
				//if (resultGet.ResponseStatus == ResponseStatus.Ok)
				//return StatusCode(StatusCodes.Status200OK, resultGet);

				return ReturnStatusCodeAndObjectResponse(resultGet);
			}
			catch (Exception ex)
			{
				return ReturnStatusCodeAndObjectResponse(ex);
			}
		}
	}



	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class RequestPersonController : AppControllerBase
	{
		private readonly IPersonRepository personRepository;
		public RequestPersonController(IPersonRepository _personRepository)
		{
			this.personRepository = _personRepository;
		}
		[AllowAnonymous]
		[ApiExplorerSettings(IgnoreApi = false)]
		[HttpGet("guid")]
		public ActionResult Response(string guid)
		{
			try
			{
				var resultGet = personRepository.dbReadOne(guid);
				var map = new BusinessLogic.Mapping.PersonMapping();
				PersonViewModel personVM = map._mapper.Map<BusinessLogic.BLLs.Person, PersonViewModel>((BusinessLogic.BLLs.Person)resultGet.ReferenceObject);
				resultGet.SetReferenceObject<PersonViewModel>(personVM);
				return ReturnStatusCodeAndObjectResponse(resultGet);
			}
			catch (Exception ex)
			{
				//return StatusCode(StatusCodes.Status500InternalServerError);
				return ReturnStatusCodeAndObjectResponse(ex);
			}
		}
	}

}

