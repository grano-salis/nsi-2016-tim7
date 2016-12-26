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
using ESjedniceServis.DbModel;
using System.Web.Http.Cors;

namespace ESjedniceServis.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UcesnikController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/Ucesnik
        public IQueryable<UCESNIK> GetUCESNIK()
        {
            return db.UCESNIK;
        }

        // GET: api/Ucesnik/5
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult GetUCESNIK(int id)
        {
            UCESNIK uCESNIK = db.UCESNIK.Find(id);
            if (uCESNIK == null)
            {
                return NotFound();
            }

            return Ok(uCESNIK);
        }

        // PUT: api/Ucesnik/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUCESNIK(int id, UCESNIK uCESNIK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uCESNIK.ID)
            {
                return BadRequest();
            }

            db.Entry(uCESNIK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UCESNIKExists(id))
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

        // POST: api/Ucesnik
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult PostUCESNIK(UCESNIK uCESNIK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UCESNIK.Add(uCESNIK);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UCESNIKExists(uCESNIK.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uCESNIK.ID }, uCESNIK);
        }

        // DELETE: api/Ucesnik/5
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult DeleteUCESNIK(int id)
        {
            UCESNIK uCESNIK = db.UCESNIK.Find(id);
            if (uCESNIK == null)
            {
                return NotFound();
            }

            db.UCESNIK.Remove(uCESNIK);
            db.SaveChanges();

            return Ok(uCESNIK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UCESNIKExists(int id)
        {
            return db.UCESNIK.Count(e => e.ID == id) > 0;
        }
    }
}