using Microsoft.AspNetCore.Mvc;

namespace CityApp.Controllers
{
    public class CityController : Controller
	{
		[HttpGet("cities")]
		[HttpGet("api/city/list")]
		public IActionResult List()
		{
			var cities = CityStorage.Instance.GetAll();
			return Json(cities);
		}

		[HttpPost("cities")]
		[HttpPost("api/city")]
		public IActionResult Create([FromBody] City city)
		{
			CityStorage.Instance.Create(city);
			return Ok();
		}

        [HttpDelete("cities")]
        [HttpDelete("api/city")]
        public IActionResult Delete([FromBody] City city)
        {
            CityStorage.Instance.Delete(city);
            return Ok();
        }

        [HttpPut("cities")]
        [HttpPut("api/city")]
        public IActionResult Change([FromBody] City city)
        {
            CityStorage.Instance.Change(city);
            return Ok();
        }

    }
}
