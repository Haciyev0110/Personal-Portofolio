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
    public class BackskilsController : Controller
    {
        private DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Backskils
        public ActionResult Index()
        {
            return View(db.Backskil.ToList());
        }

        // GET: Admin/Backskils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backskil backskil = db.Backskil.Find(id);
            if (backskil == null)
            {
                return HttpNotFound();
            }
            return View(backskil);
        }

        // GET: Admin/Backskils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Backskils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Backskil backskil)
        {
            if (ModelState.IsValid)
            {
                db.Backskil.Add(backskil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(backskil);
        }

        // GET: Admin/Backskils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backskil backskil = db.Backskil.Find(id);
            if (backskil == null)
            {
                return HttpNotFound();
            }
            return View(backskil);
        }

        // POST: Admin/Backskils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Backskil backskil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backskil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(backskil);
        }

        // GET: Admin/Backskils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backskil backskil = db.Backskil.Find(id);
            if (backskil == null)
            {
                return HttpNotFound();
            }
            return View(backskil);
        }

        // POST: Admin/Backskils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Backskil backskil = db.Backskil.Find(id);
            db.Backskil.Remove(backskil);
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
