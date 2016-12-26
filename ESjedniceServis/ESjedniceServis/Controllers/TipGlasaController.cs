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
    public class TipGlasaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/TipGlasa
        public IQueryable<TIP_GLASA> GetTIP_GLASA()
        {
            return db.TIP_GLASA;
        }

        // GET: api/TipGlasa/5
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult GetTIP_GLASA(int id)
        {
            TIP_GLASA tIP_GLASA = db.TIP_GLASA.Find(id);
            if (tIP_GLASA == null)
            {
                return NotFound();
            }

            return Ok(tIP_GLASA);
        }

        // PUT: api/TipGlasa/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIP_GLASA(int id, TIP_GLASA tIP_GLASA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIP_GLASA.ID)
            {
                return BadRequest();
            }

            db.Entry(tIP_GLASA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIP_GLASAExists(id))
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

        // POST: api/TipGlasa
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult PostTIP_GLASA(TIP_GLASA tIP_GLASA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIP_GLASA.Add(tIP_GLASA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIP_GLASAExists(tIP_GLASA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIP_GLASA.ID }, tIP_GLASA);
        }

        // DELETE: api/TipGlasa/5
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult DeleteTIP_GLASA(int id)
        {
            TIP_GLASA tIP_GLASA = db.TIP_GLASA.Find(id);
            if (tIP_GLASA == null)
            {
                return NotFound();
            }

            db.TIP_GLASA.Remove(tIP_GLASA);
            db.SaveChanges();

            return Ok(tIP_GLASA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIP_GLASAExists(int id)
        {
            return db.TIP_GLASA.Count(e => e.ID == id) > 0;
        }
    }
}