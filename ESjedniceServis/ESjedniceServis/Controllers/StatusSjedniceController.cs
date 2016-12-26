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
    public class StatusSjedniceController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/StatusSjednice
        public IQueryable<STATUS_SJEDNICE> GetSTATUS_SJEDNICE()
        {
            return db.STATUS_SJEDNICE;
        }

        // GET: api/StatusSjednice/5
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult GetSTATUS_SJEDNICE(int id)
        {
            STATUS_SJEDNICE sTATUS_SJEDNICE = db.STATUS_SJEDNICE.Find(id);
            if (sTATUS_SJEDNICE == null)
            {
                return NotFound();
            }

            return Ok(sTATUS_SJEDNICE);
        }

        // PUT: api/StatusSjednice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTATUS_SJEDNICE(int id, STATUS_SJEDNICE sTATUS_SJEDNICE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTATUS_SJEDNICE.ID)
            {
                return BadRequest();
            }

            db.Entry(sTATUS_SJEDNICE).State = EntityState.Modified;

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

        // POST: api/StatusSjednice
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult PostSTATUS_SJEDNICE(STATUS_SJEDNICE sTATUS_SJEDNICE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STATUS_SJEDNICE.Add(sTATUS_SJEDNICE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STATUS_SJEDNICEExists(sTATUS_SJEDNICE.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTATUS_SJEDNICE.ID }, sTATUS_SJEDNICE);
        }

        // DELETE: api/StatusSjednice/5
        [ResponseType(typeof(STATUS_SJEDNICE))]
        public IHttpActionResult DeleteSTATUS_SJEDNICE(int id)
        {
            STATUS_SJEDNICE sTATUS_SJEDNICE = db.STATUS_SJEDNICE.Find(id);
            if (sTATUS_SJEDNICE == null)
            {
                return NotFound();
            }

            db.STATUS_SJEDNICE.Remove(sTATUS_SJEDNICE);
            db.SaveChanges();

            return Ok(sTATUS_SJEDNICE);
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