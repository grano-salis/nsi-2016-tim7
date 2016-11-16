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
    public class PrilogController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/Prilog
        public IQueryable<PRILOG> GetPRILOGs()
        {
            return db.PRILOGs;
        }

        // GET api/Prilog/5
        [ResponseType(typeof(PRILOG))]
        public IHttpActionResult GetPRILOG(int id)
        {
            PRILOG prilog = db.PRILOGs.Find(id);
            if (prilog == null)
            {
                return NotFound();
            }

            return Ok(prilog);
        }

        // PUT api/Prilog/5
        public IHttpActionResult PutPRILOG(int id, PRILOG prilog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prilog.ID)
            {
                return BadRequest();
            }

            db.Entry(prilog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRILOGExists(id))
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

        // POST api/Prilog
        [ResponseType(typeof(PRILOG))]
        public IHttpActionResult PostPRILOG(PRILOG prilog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRILOGs.Add(prilog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRILOGExists(prilog.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prilog.ID }, prilog);
        }

        // DELETE api/Prilog/5
        [ResponseType(typeof(PRILOG))]
        public IHttpActionResult DeletePRILOG(int id)
        {
            PRILOG prilog = db.PRILOGs.Find(id);
            if (prilog == null)
            {
                return NotFound();
            }

            db.PRILOGs.Remove(prilog);
            db.SaveChanges();

            return Ok(prilog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRILOGExists(int id)
        {
            return db.PRILOGs.Count(e => e.ID == id) > 0;
        }
    }
}