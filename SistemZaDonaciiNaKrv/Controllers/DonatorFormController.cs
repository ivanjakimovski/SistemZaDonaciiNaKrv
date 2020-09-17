using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SistemZaDonaciiNaKrv.Models;

namespace SistemZaDonaciiNaKrv.Controllers
{
    public class DonatorFormController : Controller
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

        public DonatorFormController()
        {

        }

        public DonatorFormController(ApplicationUserManager userManager)
        {
            var UserManager = userManager;
        }

        // GET: DonatorForm
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            return View(db.DonatorFormModels.ToList());
        }

        // GET: DonatorForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonatorFormModel donatorFormModel = db.DonatorFormModels.Find(id);
            if (donatorFormModel == null)
            {
                return HttpNotFound();
            }
            return View(donatorFormModel);
        }

        // GET: DonatorForm/Create
        public ActionResult Create()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());

            DonatorFormModel dm = new DonatorFormModel();
            dm.DonorId = user.Id;
            dm.Name = user.FirstName;
            dm.LastName=user.LastName;
            dm.Address=user.Address;
            dm.Phone=user.PhoneNumber;
            dm.Email = user.Email;
                

            return View(dm);
        }

        // POST: DonatorForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonorId,daliOdobreno,Name,LastName,Address,Phone,Email,daliDenesSeCuvstvuvateZdravi,daliDenesNastinkaGrip,daliLekuvaleZabi,daliVakcina,daliOperacija,daliOperacijaSeriozniMedIspituvanja,daliTetovaza,daliUbod,daliTransfuzija,daliBesnilo,daliZoltica,daliBremeni,daliLekovi,daliHipofiza,daliMozocnaObvivka,daliRoznica,daliZolticaMalarija,daliSrceviPritisok,daliAlergjaAstma,daliGrcevi,daliHronicni,daliToksoPlazmoza,daliBruceloza,daliHiv,daliDroga,daliPariIliDrogaZaSex,daliHemofilijaSex,daliOdnosSoDrugMazi,daliSexSoMazKojImalSexSoDrugMaz,daliSexSoHivPozitivenIliZoltica,daliSexSoPrimatelNaDroga,daliSexSoPrimatelNaPariIliDrogaZaSex,daliCreutzfeldtJokob,daliPolovoPrenoslivaBolest")] DonatorFormModel donatorFormModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByEmail(donatorFormModel.Email);
                user.allDonatorForms.Add(donatorFormModel);
                UserManager.Update(user);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }

            return View(donatorFormModel);
        }

        // GET: DonatorForm/Edit/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonatorFormModel donatorFormModel = db.DonatorFormModels.Find(id);
            if (donatorFormModel == null)
            {
                return HttpNotFound();
            }
            return View(donatorFormModel);
        }

        // POST: DonatorForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Edit([Bind(Include = "Id,DonorId,daliOdobreno,Name,LastName,Address,Phone,Email,daliDenesSeCuvstvuvateZdravi,daliDenesNastinkaGrip,daliLekuvaleZabi,daliVakcina,daliOperacija,daliOperacijaSeriozniMedIspituvanja,daliTetovaza,daliUbod,daliTransfuzija,daliBesnilo,daliZoltica,daliBremeni,daliLekovi,daliHipofiza,daliMozocnaObvivka,daliRoznica,daliZolticaMalarija,daliSrceviPritisok,daliAlergjaAstma,daliGrcevi,daliHronicni,daliToksoPlazmoza,daliBruceloza,daliHiv,daliDroga,daliPariIliDrogaZaSex,daliHemofilijaSex,daliOdnosSoDrugMazi,daliSexSoMazKojImalSexSoDrugMaz,daliSexSoHivPozitivenIliZoltica,daliSexSoPrimatelNaDroga,daliSexSoPrimatelNaPariIliDrogaZaSex,daliCreutzfeldtJokob,daliPolovoPrenoslivaBolest")] DonatorFormModel donatorFormModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donatorFormModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donatorFormModel);
        }

        // GET: DonatorForm/Delete/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonatorFormModel donatorFormModel = db.DonatorFormModels.Find(id);
            if (donatorFormModel == null)
            {
                return HttpNotFound();
            }
            return View(donatorFormModel);
        }

        // POST: DonatorForm/Delete/5
        [Authorize(Roles = "Doctor")]
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            DonatorFormModel donatorFormModel = db.DonatorFormModels.Find(id);
            db.DonatorFormModels.Remove(donatorFormModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult ApproveForm(int id)
        {
            var formSubmit = db.DonatorFormModels.Find(id);
            formSubmit.daliOdobreno = true;

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
