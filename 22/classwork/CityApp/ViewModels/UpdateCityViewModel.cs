using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApp.ViewModels
{
    public class UpdateCityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Population { get; set; }
    }
}
