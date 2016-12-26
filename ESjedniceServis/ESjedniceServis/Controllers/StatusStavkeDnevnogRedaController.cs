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
    public class StatusStavkeDnevnogRedaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/StatusStavkeDnevnogReda
        public IQueryable<STATUS_STAVKE_DNEVNOG_REDA> GetSTATUS_STAVKE_DNEVNOG_REDA()
        {
            return db.STATUS_STAVKE_DNEVNOG_REDA;
        }

        // GET: api/StatusStavkeDnevnogReda/5
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult GetSTATUS_STAVKE_DNEVNOG_REDA(int id)
        {
            STATUS_STAVKE_DNEVNOG_REDA sTATUS_STAVKE_DNEVNOG_REDA = db.STATUS_STAVKE_DNEVNOG_REDA.Find(id);
            if (sTATUS_STAVKE_DNEVNOG_REDA == null)
            {
                return NotFound();
            }

            return Ok(sTATUS_STAVKE_DNEVNOG_REDA);
        }

        // PUT: api/StatusStavkeDnevnogReda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTATUS_STAVKE_DNEVNOG_REDA(int id, STATUS_STAVKE_DNEVNOG_REDA sTATUS_STAVKE_DNEVNOG_REDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTATUS_STAVKE_DNEVNOG_REDA.ID)
            {
                return BadRequest();
            }

            db.Entry(sTATUS_STAVKE_DNEVNOG_REDA).State = EntityState.Modified;

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

        // POST: api/StatusStavkeDnevnogReda
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult PostSTATUS_STAVKE_DNEVNOG_REDA(STATUS_STAVKE_DNEVNOG_REDA sTATUS_STAVKE_DNEVNOG_REDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_STAVKE_DNEVNOG_REDA.Add(sTATUS_STAVKE_DNEVNOG_REDA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_STAVKE_DNEVNOG_REDAExists(sTATUS_STAVKE_DNEVNOG_REDA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTATUS_STAVKE_DNEVNOG_REDA.ID }, sTATUS_STAVKE_DNEVNOG_REDA);
        }

        // DELETE: api/StatusStavkeDnevnogReda/5
        [ResponseType(typeof(STATUS_STAVKE_DNEVNOG_REDA))]
        public IHttpActionResult DeleteSTATUS_STAVKE_DNEVNOG_REDA(int id)
        {
            STATUS_STAVKE_DNEVNOG_REDA sTATUS_STAVKE_DNEVNOG_REDA = db.STATUS_STAVKE_DNEVNOG_REDA.Find(id);
            if (sTATUS_STAVKE_DNEVNOG_REDA == null)
            {
                return NotFound();
            }

            db.STATUS_STAVKE_DNEVNOG_REDA.Remove(sTATUS_STAVKE_DNEVNOG_REDA);
            db.SaveChanges();

            return Ok(sTATUS_STAVKE_DNEVNOG_REDA);
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