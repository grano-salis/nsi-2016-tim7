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
    public class TipUcesnikaController : ApiController
    {
        private DbConnection db = new DbConnection();

        // GET api/TipUcesnika
        public IQueryable<TIP_UCESNIKA> GetTIP_UCESNIKA()
        {
            return db.TIP_UCESNIKA;
        }

        // GET api/TipUcesnika/5
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult GetTIP_UCESNIKA(int id)
        {
            TIP_UCESNIKA tip_ucesnika = db.TIP_UCESNIKA.Find(id);
            if (tip_ucesnika == null)
            {
                return NotFound();
            }

            return Ok(tip_ucesnika);
        }

        // PUT api/TipUcesnika/5
        public IHttpActionResult PutTIP_UCESNIKA(int id, TIP_UCESNIKA tip_ucesnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tip_ucesnika.ID)
            {
                return BadRequest();
            }

            db.Entry(tip_ucesnika).State = EntityState.Modified;

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

        // POST api/TipUcesnika
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult PostTIP_UCESNIKA(TIP_UCESNIKA tip_ucesnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIP_UCESNIKA.Add(tip_ucesnika);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIP_UCESNIKAExists(tip_ucesnika.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tip_ucesnika.ID }, tip_ucesnika);
        }

        // DELETE api/TipUcesnika/5
        [ResponseType(typeof(TIP_UCESNIKA))]
        public IHttpActionResult DeleteTIP_UCESNIKA(int id)
        {
            TIP_UCESNIKA tip_ucesnika = db.TIP_UCESNIKA.Find(id);
            if (tip_ucesnika == null)
            {
                return NotFound();
            }

            db.TIP_UCESNIKA.Remove(tip_ucesnika);
            db.SaveChanges();

            return Ok(tip_ucesnika);
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