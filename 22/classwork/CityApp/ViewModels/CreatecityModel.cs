using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CityApp.Controllers;
using System.ComponentModel.DataAnnotations;
using CityApp.ViewModels;

namespace CityApp.WiewModels
{
	public class CreateCityModel
	{
		[Required(ErrorMessage = "Имя города не указанно")]
		[MaxLength(length: 256)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Описание города не указанно")]
		[MaxLength(length: 1024)]
		[NotCompare(nameof(Name))]
		public string Description { get; set; }

		[Required]
		[Range(minimum: 0,maximum: 120000000)]
		public int Population { get; set; }
	}
}
