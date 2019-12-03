using System.Collections.Generic;
using CityApp.Models;
using System.Linq;
using System;

namespace CityApp.Services

{
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
				new City("Москва", "Столица России", 16000000),
				
				new City("Санкт-петербург", "Северная столица России", 5000000)
				

			};
		}
		public City[] GetAll()
		{
			return _cities.ToArray();
		}

		public void Create(City city)
		{
			_cities.Add(city);
		}
		public City GetById( Guid id)
		{
			return _cities.FirstOrDefault(city => city.Id == id);
		}

	}
}
