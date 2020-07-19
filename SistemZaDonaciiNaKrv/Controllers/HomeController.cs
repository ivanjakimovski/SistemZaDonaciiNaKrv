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

        //var controller = new AccountController();

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
            var user = UserManager.FindById(User.Identity.GetUserId());

            List<DonationModel> donations;
            ViewBag.lastDonationDate = new DateTime();
            //ViewBag.lastDonationDate = new int();

            if (Request.IsAuthenticated == true)
            {
                donations = user.allDonations;

                ViewBag.lastDonationDate = donations.Count > 0 ? donations[donations.Count - 1].DonationTime : new DateTime();
                //ViewBag.lastDonationDate = donations.Count;
            }


            return View();
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