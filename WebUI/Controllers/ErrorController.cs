using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
