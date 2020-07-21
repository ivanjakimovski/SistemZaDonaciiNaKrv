using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SistemZaDonaciiNaKrv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemZaDonaciiNaKrv.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public HomeController()
        {

        }

        public HomeController(ApplicationUserManager userManager)
        {
            var UserManager = userManager;
        }

        public ActionResult Index()
        {

            if (Request.IsAuthenticated == true)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                ViewBag.lastDonationDate = new DateTime();
                List<DonationModel> donations = user.allDonations;
                ViewBag.donations = donations;

                ViewBag.lastDonationDate = donations.Count > 0 ? donations[donations.Count - 1].DonationTime : new DateTime();
            }


            return View();
        }

        public PartialViewResult PartialUserDonations()
        {
            List<DonationModel> dm = UserManager.FindById(User.Identity.GetUserId()).allDonations.ToList();
            return PartialView("_UserDonations", dm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Info()
        {
            ViewBag.Message = "Info page.";

            return View();
        }
    }
}