using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyPorftolioProject.Models;
using MyPorftolioProject.ViewModel;

namespace MyPorftolioProject.Controllers
{
    public class HomeController : Controller
    {
        DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        public ActionResult Index()
        {
            HomeVM bnm = new HomeVM();
            bnm.about = db.About.First();
            bnm.educations = db.Education.ToList();
            bnm.expriences = db.Exprience.ToList();
            bnm.porftilios = db.Porftilio.ToList();
            bnm.backskils = db.Backskil.ToList();
            bnm.frontskils = db.Frontskil.ToList();
            return View(bnm);
        }


        [HttpPost]
        public ActionResult Index3(string _from, string _subject, string _body)
        {
            MailSend mail = new MailSend();
            mail.SendMail(_from, _subject, _body);

            return Content("Error...Go Back");
        }

      
    }
}