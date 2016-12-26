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
    public class CvUserInfoController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/CvUserInfo
        public IQueryable<CV_USER_INFO> GetCV_USER_INFO()
        {
            return db.CV_USER_INFO;
        }

        // GET: api/CvUserInfo/5
        [ResponseType(typeof(CV_USER_INFO))]
        public IHttpActionResult GetCV_USER_INFO(int id)
        {
            CV_USER_INFO cV_USER_INFO = db.CV_USER_INFO.Find(id);
            if (cV_USER_INFO == null)
            {
                return NotFound();
            }

            return Ok(cV_USER_INFO);
        }

        // PUT: api/CvUserInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCV_USER_INFO(int id, CV_USER_INFO cV_USER_INFO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cV_USER_INFO.ID)
            {
                return BadRequest();
            }

            db.Entry(cV_USER_INFO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CV_USER_INFOExists(id))
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

        // POST: api/CvUserInfo
        [ResponseType(typeof(CV_USER_INFO))]
        public IHttpActionResult PostCV_USER_INFO(CV_USER_INFO cV_USER_INFO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CV_USER_INFO.Add(cV_USER_INFO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CV_USER_INFOExists(cV_USER_INFO.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cV_USER_INFO.ID }, cV_USER_INFO);
        }

        // DELETE: api/CvUserInfo/5
        [ResponseType(typeof(CV_USER_INFO))]
        public IHttpActionResult DeleteCV_USER_INFO(int id)
        {
            CV_USER_INFO cV_USER_INFO = db.CV_USER_INFO.Find(id);
            if (cV_USER_INFO == null)
            {
                return NotFound();
            }

            db.CV_USER_INFO.Remove(cV_USER_INFO);
            db.SaveChanges();

            return Ok(cV_USER_INFO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CV_USER_INFOExists(int id)
        {
            return db.CV_USER_INFO.Count(e => e.ID == id) > 0;
        }
    }
}