using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _FirstFeature : ViewComponent
    {
        FirstFeatureManager firstFeatureManager = new FirstFeatureManager(new EFFirstFeatureDal());
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
