using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService destinationService;
        public CityController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(destinationService.TGetList());
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

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination); 
            return Json(values);
        }

        public IActionResult GetById(int id)
        {

            var destinationValues = destinationService.TGetById(id);
            if (destinationValues == null)
            {
                return Json(new { message = "\"Böyle bir şehir yok\"" });
            }
            var jsonValues = JsonConvert.SerializeObject(destinationValues);
            return Json(jsonValues);
            
        }

        public IActionResult DeleteCity(int id)
        {
            var destinationValues = destinationService.TGetById(id);
            destinationService.TDelete(destinationValues);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }
    }
}
