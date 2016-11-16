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
    public class GlasController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/Glas
        public IQueryable<GLA> GetGLAS()
        {
            return db.GLAS;
        }

        // GET api/Glas/5
        [ResponseType(typeof(GLA))]
        public IHttpActionResult GetGLA(int id)
        {
            GLA gla = db.GLAS.Find(id);
            if (gla == null)
            {
                return NotFound();
            }

            return Ok(gla);
        }

        // PUT api/Glas/5
        public IHttpActionResult PutGLA(int id, GLA gla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gla.ID)
            {
                return BadRequest();
            }

            db.Entry(gla).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GLAExists(id))
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

        // POST api/Glas
        [ResponseType(typeof(GLA))]
        public IHttpActionResult PostGLA(GLA gla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GLAS.Add(gla);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GLAExists(gla.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gla.ID }, gla);
        }

        // DELETE api/Glas/5
        [ResponseType(typeof(GLA))]
        public IHttpActionResult DeleteGLA(int id)
        {
            GLA gla = db.GLAS.Find(id);
            if (gla == null)
            {
                return NotFound();
            }

            db.GLAS.Remove(gla);
            db.SaveChanges();

            return Ok(gla);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GLAExists(int id)
        {
            return db.GLAS.Count(e => e.ID == id) > 0;
        }
    }
}