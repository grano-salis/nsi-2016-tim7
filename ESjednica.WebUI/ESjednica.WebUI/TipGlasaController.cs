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
    public class TipGlasaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/TipGlasa
        public IQueryable<TIP_GLASA> GetTIP_GLASA()
        {
            return db.TIP_GLASA;
        }

        // GET api/TipGlasa/5
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult GetTIP_GLASA(int id)
        {
            TIP_GLASA tip_glasa = db.TIP_GLASA.Find(id);
            if (tip_glasa == null)
            {
                return NotFound();
            }

            return Ok(tip_glasa);
        }

        // PUT api/TipGlasa/5
        public IHttpActionResult PutTIP_GLASA(int id, TIP_GLASA tip_glasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tip_glasa.ID)
            {
                return BadRequest();
            }

            db.Entry(tip_glasa).State = EntityState.Modified;

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

        // POST api/TipGlasa
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult PostTIP_GLASA(TIP_GLASA tip_glasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIP_GLASA.Add(tip_glasa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIP_GLASAExists(tip_glasa.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tip_glasa.ID }, tip_glasa);
        }

        // DELETE api/TipGlasa/5
        [ResponseType(typeof(TIP_GLASA))]
        public IHttpActionResult DeleteTIP_GLASA(int id)
        {
            TIP_GLASA tip_glasa = db.TIP_GLASA.Find(id);
            if (tip_glasa == null)
            {
                return NotFound();
            }

            db.TIP_GLASA.Remove(tip_glasa);
            db.SaveChanges();

            return Ok(tip_glasa);
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