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
    public class StavkaDnevnogRedaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/StavkaDnevnogReda
        public IQueryable<STAVKA_DNEVNOG_REDA> GetSTAVKA_DNEVNOG_REDA()
        {
            return db.STAVKA_DNEVNOG_REDA;
        }

        // GET: api/StavkaDnevnogReda/5
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult GetSTAVKA_DNEVNOG_REDA(int id)
        {
            STAVKA_DNEVNOG_REDA sTAVKA_DNEVNOG_REDA = db.STAVKA_DNEVNOG_REDA.Find(id);
            if (sTAVKA_DNEVNOG_REDA == null)
            {
                return NotFound();
            }

            return Ok(sTAVKA_DNEVNOG_REDA);
        }

        // PUT: api/StavkaDnevnogReda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTAVKA_DNEVNOG_REDA(int id, STAVKA_DNEVNOG_REDA sTAVKA_DNEVNOG_REDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTAVKA_DNEVNOG_REDA.ID)
            {
                return BadRequest();
            }

            db.Entry(sTAVKA_DNEVNOG_REDA).State = EntityState.Modified;

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

        // POST: api/StavkaDnevnogReda
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult PostSTAVKA_DNEVNOG_REDA(STAVKA_DNEVNOG_REDA sTAVKA_DNEVNOG_REDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STAVKA_DNEVNOG_REDA.Add(sTAVKA_DNEVNOG_REDA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STAVKA_DNEVNOG_REDAExists(sTAVKA_DNEVNOG_REDA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTAVKA_DNEVNOG_REDA.ID }, sTAVKA_DNEVNOG_REDA);
        }

        // DELETE: api/StavkaDnevnogReda/5
        [ResponseType(typeof(STAVKA_DNEVNOG_REDA))]
        public IHttpActionResult DeleteSTAVKA_DNEVNOG_REDA(int id)
        {
            STAVKA_DNEVNOG_REDA sTAVKA_DNEVNOG_REDA = db.STAVKA_DNEVNOG_REDA.Find(id);
            if (sTAVKA_DNEVNOG_REDA == null)
            {
                return NotFound();
            }

            db.STAVKA_DNEVNOG_REDA.Remove(sTAVKA_DNEVNOG_REDA);
            db.SaveChanges();

            return Ok(sTAVKA_DNEVNOG_REDA);
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