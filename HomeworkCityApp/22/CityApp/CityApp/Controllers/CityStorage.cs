using System;
using System.Collections.Generic;

namespace CityApp.Controllers
{
    /// <summary>
    /// Хранилище городов
    /// </summary>
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
					Name = "Москва",
					Population = 16_000_000
				},
				new City
				{
					Id = Guid.NewGuid(),
					Name = "Санкт Петербург",
					Population = 5_000_000
				}
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

        public void Delete (City city)
        {
            _cities.Remove(_cities.Find(remote => remote.Id == city.Id));
        }

        public void Change (City city)
        {
            _cities.Remove(_cities.Find(update => update.Id == city.Id));
            _cities.Add(city);
        }
	}
}
