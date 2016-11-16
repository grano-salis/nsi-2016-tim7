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
    public class StatusStavkeDnevnogRedaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/StatusStavkeDnevnogReda
        public IQueryable<STATUS_STAVKE_DNEVNOG_REDA> GetSTATUS_STAVKE_DNEVNOG_REDA()
        {
            return db.STATUS_STAVKE_DNEVNOG_REDA;
        }

        // GET api/StatusStavkeDnevnogReda/5
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult GetSTATUS_STAVKE_DNEVNOG_REDA(int id)
        {
            STATUS_STAVKE_DNEVNOG_REDA status_stavke_dnevnog_reda = db.STATUS_STAVKE_DNEVNOG_REDA.Find(id);
            if (status_stavke_dnevnog_reda == null)
            {
                return NotFound();
            }

            return Ok(status_stavke_dnevnog_reda);
        }

        // PUT api/StatusStavkeDnevnogReda/5
        public IHttpActionResult PutSTATUS_STAVKE_DNEVNOG_REDA(int id, STATUS_STAVKE_DNEVNOG_REDA status_stavke_dnevnog_reda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != status_stavke_dnevnog_reda.ID)
            {
                return BadRequest();
            }

            db.Entry(status_stavke_dnevnog_reda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STATUS_STAVKE_DNEVNOG_REDAExists(id))
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

        // POST api/StatusStavkeDnevnogReda
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult PostSTATUS_STAVKE_DNEVNOG_REDA(STATUS_STAVKE_DNEVNOG_REDA status_stavke_dnevnog_reda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_STAVKE_DNEVNOG_REDA.Add(status_stavke_dnevnog_reda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_STAVKE_DNEVNOG_REDAExists(status_stavke_dnevnog_reda.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = status_stavke_dnevnog_reda.ID }, status_stavke_dnevnog_reda);
        }

        // DELETE api/StatusStavkeDnevnogReda/5
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult DeleteSTATUS_STAVKE_DNEVNOG_REDA(int id)
        {
            STATUS_STAVKE_DNEVNOG_REDA status_stavke_dnevnog_reda = db.STATUS_STAVKE_DNEVNOG_REDA.Find(id);
            if (status_stavke_dnevnog_reda == null)
            {
                return NotFound();
            }

            db.STATUS_STAVKE_DNEVNOG_REDA.Remove(status_stavke_dnevnog_reda);
            db.SaveChanges();

            return Ok(status_stavke_dnevnog_reda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STATUS_STAVKE_DNEVNOG_REDAExists(int id)
        {
            return db.STATUS_STAVKE_DNEVNOG_REDA.Count(e => e.ID == id) > 0;
        }
    }
}