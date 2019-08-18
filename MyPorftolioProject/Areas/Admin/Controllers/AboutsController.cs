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
    public class AboutsController : Controller
    {
        private DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Abouts
        public ActionResult Index()
        {
            return View(db.About.ToList());
        }

        // GET: Admin/Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Admin/Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Abouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descriptions,Firstname,Lastname,Birthday,Natioanly,Phone,Adress,Email,SpkenLang,Image")] About about,HttpPostedFileBase Image)
        {

            if (ModelState.IsValid)
            {

                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {
                    try
                    {
                        about.Image = Extension.SaveImg(Image, "~/Public/img");

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




                db.About.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: Admin/Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descriptions,Firstname,Lastname,Birthday,Natioanly,Phone,Adress,Email,SpkenLang")] About about,HttpPostedFileBase Image,string fileadi)
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

                        about.Image = filename;
                    }
                    else
                    {
                        ModelState.AddModelError("Img", "Dont correct");
                        return RedirectToAction("Index");
                    }
                }

                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Admin/Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Admin/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.About.Find(id);
            db.About.Remove(about);
            db.SaveChanges();
            Extension.Deletimg("~/Public/img", about.Image);
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
