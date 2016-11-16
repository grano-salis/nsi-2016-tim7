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
    public class DnevniRedController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/DnevniRed
        public IQueryable<DNEVNI_RED> GetDNEVNI_RED()
        {
            return db.DNEVNI_RED;
        }

        // GET api/DnevniRed/5
        [ResponseType(typeof(DNEVNI_RED))]
        public IHttpActionResult GetDNEVNI_RED(int id)
        {
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            if (dnevni_red == null)
            {
                return NotFound();
            }

            return Ok(dnevni_red);
        }

        // PUT api/DnevniRed/5
        public IHttpActionResult PutDNEVNI_RED(int id, DNEVNI_RED dnevni_red)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dnevni_red.ID)
            {
                return BadRequest();
            }

            db.Entry(dnevni_red).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DNEVNI_REDExists(id))
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

        // POST api/DnevniRed
        [ResponseType(typeof(DNEVNI_RED))]
        public IHttpActionResult PostDNEVNI_RED(DNEVNI_RED dnevni_red)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DNEVNI_RED.Add(dnevni_red);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DNEVNI_REDExists(dnevni_red.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dnevni_red.ID }, dnevni_red);
        }

        // DELETE api/DnevniRed/5
        [ResponseType(typeof(DNEVNI_RED))]
        public IHttpActionResult DeleteDNEVNI_RED(int id)
        {
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            if (dnevni_red == null)
            {
                return NotFound();
            }

            db.DNEVNI_RED.Remove(dnevni_red);
            db.SaveChanges();

            return Ok(dnevni_red);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DNEVNI_REDExists(int id)
        {
            return db.DNEVNI_RED.Count(e => e.ID == id) > 0;
        }
    }
}