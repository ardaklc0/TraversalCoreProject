using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialAppBrandDemo()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}

// Neden bir yerde Controller kullanmadan direkt PartialView kullandık da şimdi Controller ile kullanıyoruz?
// Senaryolar:
// Statik İçerikler: Navbar, footer gibi sabit ve veri gerektirmeyen içerikler için Razor view içinde partial view kullanımı daha uygundur.
// Dinamik İçerikler: Kullanıcı bilgisi, bildirimler, kullanıcıya özel içerikler gibi dinamik ve veri gerektiren içerikler için Controller action'ları kullanmak daha iyidir.
// Bu, verilerin Controller tarafından hazırlanıp partial view'e geçirilmesine olanak tanır.