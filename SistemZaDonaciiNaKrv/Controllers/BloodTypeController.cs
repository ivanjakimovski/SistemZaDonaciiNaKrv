using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemZaDonaciiNaKrv.Models;

namespace SistemZaDonaciiNaKrv.Controllers
{
    public class BloodTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BloodType
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.BloodTypeModels.ToList());
        }

        // GET: BloodType/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            if (bloodTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(bloodTypeModel);
        }

        // GET: BloodType/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,APositive,ANegative,BPositive,BNegative,ABPositive,ABNegative,OPositive,ONegative")] BloodTypeModel bloodTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.BloodTypeModels.Add(bloodTypeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodTypeModel);
        }

        // GET: BloodType/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            if (bloodTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(bloodTypeModel);
        }

        // POST: BloodType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,APositive,ANegative,BPositive,BNegative,ABPositive,ABNegative,OPositive,ONegative")] BloodTypeModel bloodTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodTypeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodTypeModel);
        }

        // GET: BloodType/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            if (bloodTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(bloodTypeModel);
        }

        // POST: BloodType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            db.BloodTypeModels.Remove(bloodTypeModel);
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
