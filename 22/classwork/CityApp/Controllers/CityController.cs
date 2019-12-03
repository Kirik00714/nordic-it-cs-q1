using CityApp.WiewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CityApp.Models;
using CityApp.Services;
using System;

namespace CityApp.Controllers
{

	public class CityController : Controller
	{
		[HttpGet ("cities")]
		[HttpGet("api/city/list")]
		public IActionResult List()
		{
			var cities = CityStorage.Instance
				.GetAll()
				.Select((City city) => new CityViewModel(city))
				.OrderBy((CityViewModel viewModel) => viewModel.Name).ToArray();
			return Ok(cities);
		}
		[HttpPost("cities/{id}")]
		[HttpPost("api/city/{id}")]
		public IActionResult Create([FromBody] CreateCityModel city)
		{
			if (city == null)
			{
				return BadRequest();
			}
			if (!ModelState.IsValid)
			{
				ModelState
					.Select(pair => new ValidationErrorViewModel(pair.Key, pair.Value)).ToArray();

				return BadRequest();
			}
			var model = new City(
				city.Name,
				city.Description,
				city.Population);


			CityStorage.Instance.Create(model);
			return CreatedAtAction("Get", model);
		}
		[HttpPost("cities/{id}", Name ="Get")]
		[HttpPost("api/city/{id}", Name = "ApiGet")]
		public IActionResult Get (Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}
			var city = CityStorage.Instance.GetById(id);
			if (city == null)
			{
				return NotFound();
			}
			return Ok(new DetailCityViewModel(city));
		}

	}
}
