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
    public class ChatPorukaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/ChatPoruka
        public IQueryable<CHAT_PORUKA> GetCHAT_PORUKA()
        {
            return db.CHAT_PORUKA;
        }

        // GET: api/ChatPoruka/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult GetCHAT_PORUKA(int id)
        {
            CHAT_PORUKA cHAT_PORUKA = db.CHAT_PORUKA.Find(id);
            if (cHAT_PORUKA == null)
            {
                return NotFound();
            }

            return Ok(cHAT_PORUKA);
        }

        // PUT: api/ChatPoruka/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCHAT_PORUKA(int id, CHAT_PORUKA cHAT_PORUKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cHAT_PORUKA.ID)
            {
                return BadRequest();
            }

            db.Entry(cHAT_PORUKA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHAT_PORUKAExists(id))
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

        // POST: api/ChatPoruka
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult PostCHAT_PORUKA(CHAT_PORUKA cHAT_PORUKA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHAT_PORUKA.Add(cHAT_PORUKA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CHAT_PORUKAExists(cHAT_PORUKA.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cHAT_PORUKA.ID }, cHAT_PORUKA);
        }

        // DELETE: api/ChatPoruka/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult DeleteCHAT_PORUKA(int id)
        {
            CHAT_PORUKA cHAT_PORUKA = db.CHAT_PORUKA.Find(id);
            if (cHAT_PORUKA == null)
            {
                return NotFound();
            }

            db.CHAT_PORUKA.Remove(cHAT_PORUKA);
            db.SaveChanges();

            return Ok(cHAT_PORUKA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CHAT_PORUKAExists(int id)
        {
            return db.CHAT_PORUKA.Count(e => e.ID == id) > 0;
        }
    }
}