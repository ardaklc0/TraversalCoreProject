using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    
    public class _GuideList : ViewComponent
    {
        GuideManager GuideManager = new GuideManager(new EFGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = GuideManager.TGetList();
            return View(values);
        }
    }
}
