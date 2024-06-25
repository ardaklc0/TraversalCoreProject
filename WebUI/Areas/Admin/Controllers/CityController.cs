using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(cities);
            return Json(jsonCity);
        }

        public static List<CityClassViewModel> cities = new List<CityClassViewModel>
        {
            new CityClassViewModel { Id = 1, Name = "Istanbul", Country = "Turkey" },
            new CityClassViewModel { Id = 2, Name = "New York", Country = "USA" },
            new CityClassViewModel { Id = 3, Name = "London", Country = "England" },
            new CityClassViewModel { Id = 4, Name = "Paris", Country = "France" },
            new CityClassViewModel { Id = 5, Name = "Berlin", Country = "Germany" }
        };
    }
}
