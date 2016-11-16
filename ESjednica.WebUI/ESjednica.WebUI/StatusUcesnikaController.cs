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
    public class StatusUcesnikaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/StatusUcesnika
        public IQueryable<STATUS_UCESNIKA> GetSTATUS_UCESNIKA()
        {
            return db.STATUS_UCESNIKA;
        }

        // GET api/StatusUcesnika/5
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult GetSTATUS_UCESNIKA(int id)
        {
            STATUS_UCESNIKA status_ucesnika = db.STATUS_UCESNIKA.Find(id);
            if (status_ucesnika == null)
            {
                return NotFound();
            }

            return Ok(status_ucesnika);
        }

        // PUT api/StatusUcesnika/5
        public IHttpActionResult PutSTATUS_UCESNIKA(int id, STATUS_UCESNIKA status_ucesnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != status_ucesnika.ID)
            {
                return BadRequest();
            }

            db.Entry(status_ucesnika).State = EntityState.Modified;

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

        // POST api/StatusUcesnika
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult PostSTATUS_UCESNIKA(STATUS_UCESNIKA status_ucesnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_UCESNIKA.Add(status_ucesnika);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_UCESNIKAExists(status_ucesnika.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = status_ucesnika.ID }, status_ucesnika);
        }

        // DELETE api/StatusUcesnika/5
        [ResponseType(typeof(STATUS_UCESNIKA))]
        public IHttpActionResult DeleteSTATUS_UCESNIKA(int id)
        {
            STATUS_UCESNIKA status_ucesnika = db.STATUS_UCESNIKA.Find(id);
            if (status_ucesnika == null)
            {
                return NotFound();
            }

            db.STATUS_UCESNIKA.Remove(status_ucesnika);
            db.SaveChanges();

            return Ok(status_ucesnika);
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