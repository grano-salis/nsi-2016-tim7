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
    public class StatusUcesnikaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/StatusUcesnika
        public IQueryable<STATUS_UCESNIKA> GetSTATUS_UCESNIKA()
        {
            return db.STATUS_UCESNIKA;
        }

        // GET: api/StatusUcesnika/5
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult GetSTATUS_UCESNIKA(int id)
        {
            STATUS_UCESNIKA sTATUS_UCESNIKA = db.STATUS_UCESNIKA.Find(id);
            if (sTATUS_UCESNIKA == null)
            {
                return NotFound();
            }

            return Ok(sTATUS_UCESNIKA);
        }

        // PUT: api/StatusUcesnika/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTATUS_UCESNIKA(int id, STATUS_UCESNIKA sTATUS_UCESNIKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTATUS_UCESNIKA.ID)
            {
                return BadRequest();
            }

            db.Entry(sTATUS_UCESNIKA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STATUS_UCESNIKAExists(id))
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

        // POST: api/StatusUcesnika
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult PostSTATUS_UCESNIKA(STATUS_UCESNIKA sTATUS_UCESNIKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_UCESNIKA.Add(sTATUS_UCESNIKA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_UCESNIKAExists(sTATUS_UCESNIKA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTATUS_UCESNIKA.ID }, sTATUS_UCESNIKA);
        }

        // DELETE: api/StatusUcesnika/5
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult DeleteSTATUS_UCESNIKA(int id)
        {
            STATUS_UCESNIKA sTATUS_UCESNIKA = db.STATUS_UCESNIKA.Find(id);
            if (sTATUS_UCESNIKA == null)
            {
                return NotFound();
            }

            db.STATUS_UCESNIKA.Remove(sTATUS_UCESNIKA);
            db.SaveChanges();

            return Ok(sTATUS_UCESNIKA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STATUS_UCESNIKAExists(int id)
        {
            return db.STATUS_UCESNIKA.Count(e => e.ID == id) > 0;
        }
    }
}