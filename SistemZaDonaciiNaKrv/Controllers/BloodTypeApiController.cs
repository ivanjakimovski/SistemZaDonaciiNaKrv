using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemZaDonaciiNaKrv.Models;

namespace SistemZaDonaciiNaKrv.Controllers
{
    public class BloodTypeApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BloodTypeApi
        [Authorize(Roles = "Doctor,Admin")]
        public IQueryable<BloodTypeModel> GetBloodTypeModels()
        {
            return db.BloodTypeModels;
        }

        // GET: api/BloodTypeApi/5
        [ResponseType(typeof(BloodTypeModel))]
        [Authorize(Roles = "Doctor,Admin")]
        public HttpResponseMessage GetBloodTypeModel(int id)
        {
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            if (bloodTypeModel == null)
            {
                return  Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, bloodTypeModel, Configuration.Formatters.JsonFormatter);
           // return Json(bloodTypeModel);
        }


        // PUT: api/BloodTypeApi/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutBloodTypeModel(int id, BloodTypeModel bloodTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloodTypeModel.Id)
            {
                return BadRequest();
            }

            db.Entry(bloodTypeModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodTypeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BloodTypeApi
        [ResponseType(typeof(BloodTypeModel))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostBloodTypeModel(BloodTypeModel bloodTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BloodTypeModels.Add(bloodTypeModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bloodTypeModel.Id }, bloodTypeModel);
        }

        // DELETE: api/BloodTypeApi/5
        [ResponseType(typeof(BloodTypeModel))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteBloodTypeModel(int id)
        {
            BloodTypeModel bloodTypeModel = db.BloodTypeModels.Find(id);
            if (bloodTypeModel == null)
            {
                return NotFound();
            }

            db.BloodTypeModels.Remove(bloodTypeModel);
            db.SaveChanges();

            return Ok(bloodTypeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodTypeModelExists(int id)
        {
            return db.BloodTypeModels.Count(e => e.Id == id) > 0;
        }
    }
}