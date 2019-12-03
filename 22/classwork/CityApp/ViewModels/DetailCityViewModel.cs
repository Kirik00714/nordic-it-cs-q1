using CityApp.Models;

namespace CityApp.WiewModels
{
	public class DetailCityViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Population { get; set; }
		public DetailCityViewModel()
		{

		}
		public DetailCityViewModel(City city)
		{
			Id = city.Id.ToString("N");
			Name = city.Name;
			Description = city.Description;
			Population = city.Population;
		}
	}
}
