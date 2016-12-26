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
    public class GlasController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/GlasS
        public IQueryable<GLAS> GetGLAS()
        {
            return db.GLAS;
        }

        // GET: api/GlasS/5
        [ResponseType(typeof(GLAS))]
        public IHttpActionResult GetGLAS(int id)
        {
            GLAS gLAS = db.GLAS.Find(id);
            if (gLAS == null)
            {
                return NotFound();
            }

            return Ok(gLAS);
        }

        // PUT: api/GlasS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGLAS(int id, GLAS gLAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gLAS.ID)
            {
                return BadRequest();
            }

            db.Entry(gLAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GLASExists(id))
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

        // POST: api/GlasS
        [ResponseType(typeof(GLAS))]
        public IHttpActionResult PostGLAS(GLAS gLAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GLAS.Add(gLAS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GLASExists(gLAS.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gLAS.ID }, gLAS);
        }

        // DELETE: api/GlasS/5
        [ResponseType(typeof(GLAS))]
        public IHttpActionResult DeleteGLAS(int id)
        {
            GLAS gLAS = db.GLAS.Find(id);
            if (gLAS == null)
            {
                return NotFound();
            }

            db.GLAS.Remove(gLAS);
            db.SaveChanges();

            return Ok(gLAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GLASExists(int id)
        {
            return db.GLAS.Count(e => e.ID == id) > 0;
        }
    }
}