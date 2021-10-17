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
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}

	[ApiController]
	[Route("api")]
	public class apiController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult> api()
		{
			return StatusCode(StatusCodes.Status200OK, $"ok: {DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString()}");
		}
	}


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

}
