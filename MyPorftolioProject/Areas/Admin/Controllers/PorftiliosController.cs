using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPorftolioProject.Extino;
using MyPorftolioProject.Models;
using MyPorftolioProject.ViewModel;

namespace MyPorftolioProject.Areas.Admin.Controllers
{
    [Authorizem]
    public class PorftiliosController : Controller
    {
        private DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Porftilios
        public ActionResult Index()
        {
            return View(db.Porftilio.ToList());
        }

        // GET: Admin/Porftilios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Porftilio porftilio = db.Porftilio.Find(id);
            if (porftilio == null)
            {
                return HttpNotFound();
            }
            return View(porftilio);
        }

        // GET: Admin/Porftilios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Porftilios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Client,Duation,UsedTech,LinlUrl")] Porftilio porftilio,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {

                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            porftilio.Image = Extension.SaveImg(Image, "~/Public/img");

                        }
                        catch
                        {

                            ModelState.AddModelError("Img", "Img is not correct");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Img", "Img is not correct");
                    }
                    db.Porftilio.Add(porftilio);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(porftilio);
        }

        // GET: Admin/Porftilios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Porftilio porftilio = db.Porftilio.Find(id);
            if (porftilio == null)
            {
                return HttpNotFound();
            }
            return View(porftilio);
        }

        // POST: Admin/Porftilios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image,Client,Duation,UsedTech,LinlUrl")] Porftilio porftilio,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {

                if (Image != null)
                {

                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        string filename;
                        try
                        {
                            filename = Extension.SaveImg(Image, "~/Public/img");

                        }
                        catch (Exception)
                        {
                            ModelState.AddModelError("Image", "Dont correct");
                            return RedirectToAction("Index");
                        }


                        Extension.Deletimg("~/Public/img", fileadi);

                        porftilio.Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    porftilio.Image = fileadi;
                }

                db.Entry(porftilio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(porftilio);
        }

        // GET: Admin/Porftilios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Porftilio porftilio = db.Porftilio.Find(id);
            if (porftilio == null)
            {
                return HttpNotFound();
            }
            return View(porftilio);
        }

        // POST: Admin/Porftilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Porftilio porftilio = db.Porftilio.Find(id);
            db.Porftilio.Remove(porftilio);
            Extension.Deletimg("~/Public/img", porftilio.Image);

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
