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
using ESjedniceServis.Models;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Http.Cors;

namespace ESjedniceServis.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PrilogController : ApiController
    {
        private eSjedniceEntities db = new eSjedniceEntities();

        // GET: api/Prilog
        [ResponseType(typeof(PrilogDTO))]
        public IQueryable<PrilogDTO> GetPRILOG()
        {
            return from p in db.PRILOG
                   select new PrilogDTO()
                   {
                       ContentType = p.CONTENT_TYPE,
                       Id = p.ID,
                       Naziv = p.NAZIV,
                       Sadrzaj = null
                   };
        }

        // GET: api/Prilog/5
        [ResponseType(typeof(PrilogDTO))]
        public IHttpActionResult GetPRILOG(int id)
        {
            PRILOG pRILOG = db.PRILOG.Find(id);
            if (pRILOG == null)
            {
                return NotFound();
            }
            PrilogDTO model = new PrilogDTO()
            {
                ContentType = pRILOG.CONTENT_TYPE,
                Id = pRILOG.ID,
                Naziv = pRILOG.NAZIV
            };



            return Ok(model);
        }

        // PUT: api/Prilog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRILOG(int id, PRILOG pRILOG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRILOG.ID)
            {
                return BadRequest();
            }

            db.Entry(pRILOG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRILOGExists(id))
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


        [HttpPost]
        public async Task<HttpResponseMessage> PostPRILOG()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //var prilog = await Request.Content.ReadAsAsync<PrilogDTO>();

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                PRILOG model = new PRILOG()
                {
                    NAZIV = provider.FormData.Get("naziv"),
                    CONTENT_TYPE = provider.FileData[0].Headers.ContentType.MediaType,
                    SADRZAJ = File.ReadAllBytes(provider.FileData[0].LocalFileName),
                    SJEDNICA = db.SJEDNICA.Find(Convert.ToInt32(provider.FormData.Get("sjednicaid")))

                };

                db.PRILOG.Add(model);
                db.SaveChanges();
                File.Delete(provider.FileData[0].LocalFileName);
                //  model.SADRZAJ = null;
                // GetPRILOG(model.ID);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        // DELETE: api/Prilog/5
        [ResponseType(typeof(PRILOG))]
        public IHttpActionResult DeletePRILOG(int id)
        {
            PRILOG pRILOG = db.PRILOG.Find(id);
            if (pRILOG == null)
            {
                return NotFound();
            }

            db.PRILOG.Remove(pRILOG);
            db.SaveChanges();

            return Ok(pRILOG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRILOGExists(int id)
        {
            return db.PRILOG.Count(e => e.ID == id) > 0;
        }
    }
}