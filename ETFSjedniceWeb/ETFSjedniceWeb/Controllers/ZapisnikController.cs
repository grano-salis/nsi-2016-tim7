using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETFSjedniceWeb.Controllers
{
    public class ZapisnikController : Controller
    {
        //
        // GET: /Zapisnik/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Zapisnik/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Zapisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Zapisnik/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Zapisnik/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Zapisnik/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Zapisnik/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Zapisnik/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
