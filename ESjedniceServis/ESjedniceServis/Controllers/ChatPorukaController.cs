using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ESjedniceServis.DbModel;

namespace ESjedniceServis.Controllers
{
    public class ChatPorukaController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/CHAT_PORUKA
        public IQueryable<CHAT_PORUKA> GetCHAT_PORUKA()
        {
            return db.CHAT_PORUKA;
        }

        // GET: api/CHAT_PORUKA/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public async Task<IHttpActionResult> GetCHAT_PORUKA(int id)
        {
            CHAT_PORUKA cHAT_PORUKA = await db.CHAT_PORUKA.FindAsync(id);
            if (cHAT_PORUKA == null)
            {
                return NotFound();
            }

            return Ok(cHAT_PORUKA);
        }

        // PUT: api/CHAT_PORUKA/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCHAT_PORUKA(int id, CHAT_PORUKA cHAT_PORUKA)
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
                await db.SaveChangesAsync();
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

        // POST: api/CHAT_PORUKA
        [ResponseType(typeof(CHAT_PORUKA))]
        public async Task<IHttpActionResult> PostCHAT_PORUKA(CHAT_PORUKA cHAT_PORUKA)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CHAT_PORUKA.Add(cHAT_PORUKA);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cHAT_PORUKA.ID }, cHAT_PORUKA);
        }

        // DELETE: api/CHAT_PORUKA/5
        [ResponseType(typeof(CHAT_PORUKA))]
        public async Task<IHttpActionResult> DeleteCHAT_PORUKA(int id)
        {
            CHAT_PORUKA cHAT_PORUKA = await db.CHAT_PORUKA.FindAsync(id);
            if (cHAT_PORUKA == null)
            {
                return NotFound();
            }

            db.CHAT_PORUKA.Remove(cHAT_PORUKA);
            await db.SaveChangesAsync();

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