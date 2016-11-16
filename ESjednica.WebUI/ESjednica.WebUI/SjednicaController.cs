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
    public class SjednicaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/Sjednica
        public IQueryable<SJEDNICA> GetSJEDNICAs()
        {
            return db.SJEDNICAs;
        }

        // GET api/Sjednica/5
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult GetSJEDNICA(int id)
        {
            SJEDNICA sjednica = db.SJEDNICAs.Find(id);
            if (sjednica == null)
            {
                return NotFound();
            }

            return Ok(sjednica);
        }

        // PUT api/Sjednica/5
        public IHttpActionResult PutSJEDNICA(int id, SJEDNICA sjednica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sjednica.ID)
            {
                return BadRequest();
            }

            db.Entry(sjednica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SJEDNICAExists(id))
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

        // POST api/Sjednica
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult PostSJEDNICA(SJEDNICA sjednica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SJEDNICAs.Add(sjednica);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SJEDNICAExists(sjednica.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sjednica.ID }, sjednica);
        }

        // DELETE api/Sjednica/5
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult DeleteSJEDNICA(int id)
        {
            SJEDNICA sjednica = db.SJEDNICAs.Find(id);
            if (sjednica == null)
            {
                return NotFound();
            }

            db.SJEDNICAs.Remove(sjednica);
            db.SaveChanges();

            return Ok(sjednica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SJEDNICAExists(int id)
        {
            return db.SJEDNICAs.Count(e => e.ID == id) > 0;
        }
    }
}