using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApp.Controllers
{
	//Обрабатыевает всю логику по управлению городами
	public class City
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Population { get; set; }
	}
	public class CityStorage
	{
		private static CityStorage _instance;
		public static CityStorage Instance =>
			_instance ?? (_instance = new CityStorage());
		private readonly List<City> _cities;
		private CityStorage()
		{
			_cities = new List<City>
			{
				new City
				{
					Id = Guid.NewGuid(),
					Name = "Moscow",
					Population = 16_000_000
				},
				new City
				{
					Id = Guid.NewGuid(),
					Name = "Санкт-Петербург",
					Population = 5_000_000
				},

			};
		}
		public City[] GetAll()
		{
			return _cities.ToArray();
		}

		public vois Create(City city)
		{
			_cities.Add(city);
		}


	}

	public class CityController : Controller
	{
		[HttpGet ("cities")]
		[HttpGet("api/city/list")]
		public IActionResult List()
		{
			var storage = new CityStorage.Instance.GetAll();
			return Json(cities);
		}
		[HttpPost("cities")]
		[HttpPost("api/city")]
		public IActionResult Create([FromBody] City city)
		{
			CityStorage.Instance.Create(city);
			return Ok();
		}

	}
}
