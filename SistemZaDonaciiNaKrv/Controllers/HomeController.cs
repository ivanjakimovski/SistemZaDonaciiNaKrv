using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SistemZaDonaciiNaKrv.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebGrease.Css.Extensions;

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
                ViewBag.lastDonationDatePlusSixMonths = donations.Count > 0 ? donations[donations.Count - 1].DonationTime.AddMonths(6) : new DateTime();
                //ViewBag.lastDonationDatePlusSixMonths = lastDonationDatePlusSixMonths.ToString();
                return View(donations);
            }


            return View();
        }

        public PartialViewResult PartialUserDonations()
        {
            List<DonationModel> dm = UserManager.FindById(User.Identity.GetUserId()).allDonations.ToList();
            return PartialView("_UserDonations", dm);
        }

        public ActionResult AllDonationsView()
        {

            List<DonationModelDisplay> donations = new List<DonationModelDisplay>();

            return View(db.DonationModels.ToList());
        }


        [Authorize(Roles = "Admin,Doctor")]
        public ActionResult AllDonorsView()
        {

            List<ApplicationUser> list = new List<ApplicationUser>();

            foreach(ApplicationUser user in UserManager.Users.ToList())
            {
                foreach(var item in user.Roles)
                {
                    if(item.RoleId == "3" || item.RoleId == "2")
                    {
                        continue;
                    } else 
                    {
                        list.Add(user);
                    }
                }
                
             
            }

            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult MakeUserDoctor(string email)
        {
            var user = UserManager.FindByEmail(email);
            UserManager.RemoveFromRole(user.Id, "Donor");
            UserManager.AddToRole(user.Id, "Doctor");

            return RedirectToAction("AllDonorsView");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult BookAppointment()
        {
            var appointment = Request.QueryString["appointment"];
            var email = Request.QueryString["email"];
            var formId = Request.QueryString["formId"];

            var user = UserManager.FindByEmail(email);
        
            DonationModel newDonation = new DonationModel();
            newDonation.City = user.City;
            newDonation.DonationTime = Convert.ToDateTime(appointment);
            newDonation.isDone = false;
            newDonation.Name = user.FirstName;
            newDonation.LastName = user.LastName;
            newDonation.Email = user.Email;
            newDonation.bloodType = user.bloodType;

            user.allDonations.Add(newDonation);

            UserManager.Update(user);

            var formToDelete = db.DonatorFormModels.Find(Convert.ToInt32(formId));
            db.DonatorFormModels.Remove(formToDelete);
            db.SaveChanges();

            return Redirect("/DonatorForm/Index");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult AddBlood()
        {
            var bloodType = Request.QueryString["bloodType"];
            var donationId = Request.QueryString["donationId"];

            var bloodReserves = db.BloodTypeModels.Find(1);

            if(bloodType.Equals("APositive"))
            {
                bloodReserves.APositive = bloodReserves.APositive + 1;
            }
            if (bloodType.Equals("ANegative"))
            {
                bloodReserves.ANegative = bloodReserves.ANegative + 1;
            }

            if (bloodType.Equals("BPositive"))
            {
                bloodReserves.BPositive = bloodReserves.BPositive + 1;
            }
            if (bloodType.Equals("BNegative"))
            {
                bloodReserves.BNegative = bloodReserves.BNegative + 1;
            }

            if (bloodType.Equals("ABPositive"))
            {
                bloodReserves.ABPositive = bloodReserves.ABPositive + 1;
            }
            if (bloodType.Equals("ABNegative"))
            {
                bloodReserves.ABNegative = bloodReserves.ABNegative + 1;
            }

            if (bloodType.Equals("OPositive"))
            {
                bloodReserves.OPositive = bloodReserves.OPositive + 1;
            }
            if (bloodType.Equals("ONegative"))
            {
                bloodReserves.ONegative = bloodReserves.ONegative + 1;
            }

            var donation = db.DonationModels.Find(Convert.ToInt32(donationId));
            donation.isDone = true;

            db.SaveChanges();

            return Redirect("/Home/AllDonationsView");

        }

        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteDonation(string id)
        {
            var donationToRemove = db.DonationModels.Find(Convert.ToInt32(id));
            db.DonationModels.Remove(donationToRemove);
            db.SaveChanges();

            return Redirect("/Home/AllDonationsView");
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