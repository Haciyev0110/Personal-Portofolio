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
    public class ExpriencesController : Controller
    {
        private DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Expriences
        public ActionResult Index()
        {
            return View(db.Exprience.ToList());
        }

        // GET: Admin/Expriences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exprience exprience = db.Exprience.Find(id);
            if (exprience == null)
            {
                return HttpNotFound();
            }
            return View(exprience);
        }

        // GET: Admin/Expriences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Expriences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Companyname,Companyspecial,Minidesc")] Exprience exprience)
        {
            if (ModelState.IsValid)
            {
                db.Exprience.Add(exprience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exprience);
        }

        // GET: Admin/Expriences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exprience exprience = db.Exprience.Find(id);
            if (exprience == null)
            {
                return HttpNotFound();
            }
            return View(exprience);
        }

        // POST: Admin/Expriences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Companyname,Companyspecial,Minidesc")] Exprience exprience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exprience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exprience);
        }

        // GET: Admin/Expriences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exprience exprience = db.Exprience.Find(id);
            if (exprience == null)
            {
                return HttpNotFound();
            }
            return View(exprience);
        }

        // POST: Admin/Expriences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exprience exprience = db.Exprience.Find(id);
            db.Exprience.Remove(exprience);
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
