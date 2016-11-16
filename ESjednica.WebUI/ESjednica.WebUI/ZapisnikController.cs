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
    public class ZapisnikController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/Zapisnik
        public IQueryable<ZAPISNIK> GetZAPISNIKs()
        {
            return db.ZAPISNIKs;
        }

        // GET api/Zapisnik/5
        [ResponseType(typeof(ZAPISNIK))]
        public IHttpActionResult GetZAPISNIK(int id)
        {
            ZAPISNIK zapisnik = db.ZAPISNIKs.Find(id);
            if (zapisnik == null)
            {
                return NotFound();
            }

            return Ok(zapisnik);
        }

        // PUT api/Zapisnik/5
        public IHttpActionResult PutZAPISNIK(int id, ZAPISNIK zapisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zapisnik.ID)
            {
                return BadRequest();
            }

            db.Entry(zapisnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZAPISNIKExists(id))
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

        // POST api/Zapisnik
        [ResponseType(typeof(ZAPISNIK))]
        public IHttpActionResult PostZAPISNIK(ZAPISNIK zapisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZAPISNIKs.Add(zapisnik);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZAPISNIKExists(zapisnik.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zapisnik.ID }, zapisnik);
        }

        // DELETE api/Zapisnik/5
        [ResponseType(typeof(ZAPISNIK))]
        public IHttpActionResult DeleteZAPISNIK(int id)
        {
            ZAPISNIK zapisnik = db.ZAPISNIKs.Find(id);
            if (zapisnik == null)
            {
                return NotFound();
            }

            db.ZAPISNIKs.Remove(zapisnik);
            db.SaveChanges();

            return Ok(zapisnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZAPISNIKExists(int id)
        {
            return db.ZAPISNIKs.Count(e => e.ID == id) > 0;
        }
    }
}