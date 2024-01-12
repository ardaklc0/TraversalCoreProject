using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

//MVC'de Partial'lara URL üstünden direkt erişim sağlanabiliyor. Fakat ViewComponent'lere erişim sağlanmıyor.