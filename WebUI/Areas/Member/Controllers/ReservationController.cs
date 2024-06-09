using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EFReservationDal());

        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var reservations = reservationManager.GetListWithReservationByAccepted(values.Id);
            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> MyOldReservations()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var reservations = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> MyApprovalReservations()
        {       
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var reservations = reservationManager.GetListWithReservationByWaitApproval(values.Id);
            return View(reservations);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 4;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservations");
        }
    }
}
