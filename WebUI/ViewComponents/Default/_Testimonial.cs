 
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var testimonials = testimonialManager.TGetList();
            return View(testimonials);
        }
    }
}
