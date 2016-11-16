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
    public class StavkaDnevnogRedaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/StavkaDnevnogReda
        public IQueryable<STAVKA_DNEVNOG_REDA> GetSTAVKA_DNEVNOG_REDA()
        {
            return db.STAVKA_DNEVNOG_REDA;
        }

        // GET api/StavkaDnevnogReda/5
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult GetSTAVKA_DNEVNOG_REDA(int id)
        {
            STAVKA_DNEVNOG_REDA stavka_dnevnog_reda = db.STAVKA_DNEVNOG_REDA.Find(id);
            if (stavka_dnevnog_reda == null)
            {
                return NotFound();
            }

            return Ok(stavka_dnevnog_reda);
        }

        // PUT api/StavkaDnevnogReda/5
        public IHttpActionResult PutSTAVKA_DNEVNOG_REDA(int id, STAVKA_DNEVNOG_REDA stavka_dnevnog_reda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka_dnevnog_reda.ID)
            {
                return BadRequest();
            }

            db.Entry(stavka_dnevnog_reda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STAVKA_DNEVNOG_REDAExists(id))
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

        // POST api/StavkaDnevnogReda
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult PostSTAVKA_DNEVNOG_REDA(STAVKA_DNEVNOG_REDA stavka_dnevnog_reda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STAVKA_DNEVNOG_REDA.Add(stavka_dnevnog_reda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STAVKA_DNEVNOG_REDAExists(stavka_dnevnog_reda.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stavka_dnevnog_reda.ID }, stavka_dnevnog_reda);
        }

        // DELETE api/StavkaDnevnogReda/5
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult DeleteSTAVKA_DNEVNOG_REDA(int id)
        {
            STAVKA_DNEVNOG_REDA stavka_dnevnog_reda = db.STAVKA_DNEVNOG_REDA.Find(id);
            if (stavka_dnevnog_reda == null)
            {
                return NotFound();
            }

            db.STAVKA_DNEVNOG_REDA.Remove(stavka_dnevnog_reda);
            db.SaveChanges();

            return Ok(stavka_dnevnog_reda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STAVKA_DNEVNOG_REDAExists(int id)
        {
            return db.STAVKA_DNEVNOG_REDA.Count(e => e.ID == id) > 0;
        }
    }
}