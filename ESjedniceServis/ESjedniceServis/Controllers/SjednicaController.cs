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
    public class SjednicaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();
        public SjednicaController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Sjednica
        public IQueryable<SJEDNICA> GetSJEDNICA()
        {
            return db.SJEDNICA;
        }

        // GET: api/Sjednica/5
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult GetSJEDNICA(int id)
        {
            SJEDNICA sJEDNICA = db.SJEDNICA.Find(id);
            if (sJEDNICA == null)
            {
                return NotFound();
            }

            return Ok(sJEDNICA);
        }

        // PUT: api/Sjednica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSJEDNICA(int id, SJEDNICA sJEDNICA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sJEDNICA.ID)
            {
                return BadRequest();
            }

            db.Entry(sJEDNICA).State = EntityState.Modified;

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

        // POST: api/Sjednica
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult PostSJEDNICA(SJEDNICA sJEDNICA)
        {
            //sJEDNICA.ID = 99;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sJEDNICA.STATUS_SJEDNICE = db.STATUS_SJEDNICE.Find(7);
            db.SJEDNICA.Add(sJEDNICA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SJEDNICAExists(sJEDNICA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sJEDNICA.ID }, sJEDNICA);
        }

        // DELETE: api/Sjednica/5
        [ResponseType(typeof(SJEDNICA))]
        public IHttpActionResult DeleteSJEDNICA(int id)
        {
            SJEDNICA sJEDNICA = db.SJEDNICA.Find(id);
            if (sJEDNICA == null)
            {
                return NotFound();
            }

            db.SJEDNICA.Remove(sJEDNICA);
            db.SaveChanges();

            return Ok(sJEDNICA);
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
            return db.SJEDNICA.Count(e => e.ID == id) > 0;
        }
    }
}