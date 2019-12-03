using CityApp.Models;

namespace CityApp.WiewModels
{
	public class CityViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public CityViewModel()
		{

		}
		public CityViewModel(City city)
		{
			Id = city.Id.ToString("N");
			Name = city.Name;
		}
	}
}
