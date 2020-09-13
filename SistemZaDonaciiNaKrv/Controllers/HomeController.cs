﻿using Microsoft.Ajax.Utilities;
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
                return View(donations);
            }


            return View();
        }

        public PartialViewResult PartialUserDonations()
        {
            List<DonationModel> dm = UserManager.FindById(User.Identity.GetUserId()).allDonations.ToList();
            return PartialView("_UserDonations", dm);
        }

        
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