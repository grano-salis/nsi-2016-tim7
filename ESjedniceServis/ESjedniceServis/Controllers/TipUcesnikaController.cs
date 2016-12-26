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
    public class TipUcesnikaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/TipUcesnika
        public IQueryable<TIP_UCESNIKA> GetTIP_UCESNIKA()
        {
            return db.TIP_UCESNIKA;
        }

        // GET: api/TipUcesnika/5
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult GetTIP_UCESNIKA(int id)
        {
            TIP_UCESNIKA tIP_UCESNIKA = db.TIP_UCESNIKA.Find(id);
            if (tIP_UCESNIKA == null)
            {
                return NotFound();
            }

            return Ok(tIP_UCESNIKA);
        }

        // PUT: api/TipUcesnika/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIP_UCESNIKA(int id, TIP_UCESNIKA tIP_UCESNIKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIP_UCESNIKA.ID)
            {
                return BadRequest();
            }

            db.Entry(tIP_UCESNIKA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIP_UCESNIKAExists(id))
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

        // POST: api/TipUcesnika
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult PostTIP_UCESNIKA(TIP_UCESNIKA tIP_UCESNIKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIP_UCESNIKA.Add(tIP_UCESNIKA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIP_UCESNIKAExists(tIP_UCESNIKA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIP_UCESNIKA.ID }, tIP_UCESNIKA);
        }

        // DELETE: api/TipUcesnika/5
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult DeleteTIP_UCESNIKA(int id)
        {
            TIP_UCESNIKA tIP_UCESNIKA = db.TIP_UCESNIKA.Find(id);
            if (tIP_UCESNIKA == null)
            {
                return NotFound();
            }

            db.TIP_UCESNIKA.Remove(tIP_UCESNIKA);
            db.SaveChanges();

            return Ok(tIP_UCESNIKA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIP_UCESNIKAExists(int id)
        {
            return db.TIP_UCESNIKA.Count(e => e.ID == id) > 0;
        }
    }
}