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
    public class StatusSjedniceController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/StatusSjednice
        public IQueryable<STATUS_SJEDNICE> GetSTATUS_SJEDNICE()
        {
            return db.STATUS_SJEDNICE;
        }

        // GET api/StatusSjednice/5
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult GetSTATUS_SJEDNICE(int id)
        {
            STATUS_SJEDNICE status_sjednice = db.STATUS_SJEDNICE.Find(id);
            if (status_sjednice == null)
            {
                return NotFound();
            }

            return Ok(status_sjednice);
        }

        // PUT api/StatusSjednice/5
        public IHttpActionResult PutSTATUS_SJEDNICE(int id, STATUS_SJEDNICE status_sjednice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != status_sjednice.ID)
            {
                return BadRequest();
            }

            db.Entry(status_sjednice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STATUS_SJEDNICEExists(id))
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

        // POST api/StatusSjednice
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult PostSTATUS_SJEDNICE(STATUS_SJEDNICE status_sjednice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_SJEDNICE.Add(status_sjednice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_SJEDNICEExists(status_sjednice.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = status_sjednice.ID }, status_sjednice);
        }

        // DELETE api/StatusSjednice/5
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult DeleteSTATUS_SJEDNICE(int id)
        {
            STATUS_SJEDNICE status_sjednice = db.STATUS_SJEDNICE.Find(id);
            if (status_sjednice == null)
            {
                return NotFound();
            }

            db.STATUS_SJEDNICE.Remove(status_sjednice);
            db.SaveChanges();

            return Ok(status_sjednice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STATUS_SJEDNICEExists(int id)
        {
            return db.STATUS_SJEDNICE.Count(e => e.ID == id) > 0;
        }
    }
}