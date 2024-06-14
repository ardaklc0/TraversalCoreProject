using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            destinationManager.TAdd(destination);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            var value = destinationManager.TGetById(id);
            destinationManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = destinationManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destination.Status = true;
            destinationManager.TUpdate(destination);
            return RedirectToAction("Index");
        }
    }
}
