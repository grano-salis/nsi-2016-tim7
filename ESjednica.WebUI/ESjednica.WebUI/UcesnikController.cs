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

namespace ESjednica.WebUI
{
    public class UcesnikController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/Ucesnik
        public IQueryable<UCESNIK> GetUCESNIKs()
        {
            return db.UCESNIKs;
        }

        // GET api/Ucesnik/5
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult GetUCESNIK(int id)
        {
            UCESNIK ucesnik = db.UCESNIKs.Find(id);
            if (ucesnik == null)
            {
                return NotFound();
            }

            return Ok(ucesnik);
        }

        // PUT api/Ucesnik/5
        public IHttpActionResult PutUCESNIK(int id, UCESNIK ucesnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ucesnik.ID)
            {
                return BadRequest();
            }

            db.Entry(ucesnik).State = EntityState.Modified;

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

        // POST api/Ucesnik
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult PostUCESNIK(UCESNIK ucesnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UCESNIKs.Add(ucesnik);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UCESNIKExists(ucesnik.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ucesnik.ID }, ucesnik);
        }

        // DELETE api/Ucesnik/5
        [ResponseType(typeof(UCESNIK))]
        public IHttpActionResult DeleteUCESNIK(int id)
        {
            UCESNIK ucesnik = db.UCESNIKs.Find(id);
            if (ucesnik == null)
            {
                return NotFound();
            }

            db.UCESNIKs.Remove(ucesnik);
            db.SaveChanges();

            return Ok(ucesnik);
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
            return db.UCESNIKs.Count(e => e.ID == id) > 0;
        }
    }
}