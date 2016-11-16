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
    public class ChatPorukaController : ApiController
    {
        private DbConnection db = new DbConnection();

        public ChatPorukaController()
        {
            //db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/ChatPoruka
        public IQueryable<CHAT_PORUKA> GetCHAT_PORUKA()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            return db.CHAT_PORUKA;
        }

        // GET api/ChatPoruka/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult GetCHAT_PORUKA(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            CHAT_PORUKA chat_poruka = db.CHAT_PORUKA.Find(id);
            if (chat_poruka == null)
            {
                return NotFound();
            }

            return Ok(chat_poruka);
        }

        // PUT api/ChatPoruka/5
        public IHttpActionResult PutCHAT_PORUKA(int id, CHAT_PORUKA chat_poruka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chat_poruka.ID)
            {
                return BadRequest();
            }

            db.Entry(chat_poruka).State = EntityState.Modified;

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

        // POST api/ChatPoruka
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult PostCHAT_PORUKA(CHAT_PORUKA chat_poruka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHAT_PORUKA.Add(chat_poruka);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CHAT_PORUKAExists(chat_poruka.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chat_poruka.ID }, chat_poruka);
        }

        // DELETE api/ChatPoruka/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public IHttpActionResult DeleteCHAT_PORUKA(int id)
        {
            CHAT_PORUKA chat_poruka = db.CHAT_PORUKA.Find(id);
            if (chat_poruka == null)
            {
                return NotFound();
            }

            db.CHAT_PORUKA.Remove(chat_poruka);
            db.SaveChanges();

            return Ok(chat_poruka);
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