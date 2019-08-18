using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPorftolioProject.Models;
using MyPorftolioProject.ViewModel;

namespace MyPorftolioProject.Areas.Admin.Controllers
{
    [Authorizem]
    public class FrontskilsController : Controller
    {
        private DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Frontskils
        public ActionResult Index()
        {
            return View(db.Frontskil.ToList());
        }

        // GET: Admin/Frontskils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frontskil frontskil = db.Frontskil.Find(id);
            if (frontskil == null)
            {
                return HttpNotFound();
            }
            return View(frontskil);
        }

        // GET: Admin/Frontskils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Frontskils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Frontskil frontskil)
        {
            if (ModelState.IsValid)
            {
                db.Frontskil.Add(frontskil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frontskil);
        }

        // GET: Admin/Frontskils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frontskil frontskil = db.Frontskil.Find(id);
            if (frontskil == null)
            {
                return HttpNotFound();
            }
            return View(frontskil);
        }

        // POST: Admin/Frontskils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Frontskil frontskil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frontskil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frontskil);
        }

        // GET: Admin/Frontskils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frontskil frontskil = db.Frontskil.Find(id);
            if (frontskil == null)
            {
                return HttpNotFound();
            }
            return View(frontskil);
        }

        // POST: Admin/Frontskils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Frontskil frontskil = db.Frontskil.Find(id);
            db.Frontskil.Remove(frontskil);
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
