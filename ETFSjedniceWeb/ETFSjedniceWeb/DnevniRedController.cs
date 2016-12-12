using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETFSjedniceWeb.Models;

namespace ETFSjedniceWeb
{
    public class DnevniRedController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /DnevniRed/
        public ActionResult Index()
        {
            return View(db.DNEVNI_RED.ToList());
        }

        // GET: /DnevniRed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            if (dnevni_red == null)
            {
                return HttpNotFound();
            }
            return View(dnevni_red);
        }

        // GET: /DnevniRed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DnevniRed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID")] DNEVNI_RED dnevni_red)
        {
            if (ModelState.IsValid)
            {
                db.DNEVNI_RED.Add(dnevni_red);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dnevni_red);
        }

        // GET: /DnevniRed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            if (dnevni_red == null)
            {
                return HttpNotFound();
            }
            return View(dnevni_red);
        }

        // POST: /DnevniRed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID")] DNEVNI_RED dnevni_red)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dnevni_red).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dnevni_red);
        }

        // GET: /DnevniRed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            if (dnevni_red == null)
            {
                return HttpNotFound();
            }
            return View(dnevni_red);
        }

        // POST: /DnevniRed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DNEVNI_RED dnevni_red = db.DNEVNI_RED.Find(id);
            db.DNEVNI_RED.Remove(dnevni_red);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
