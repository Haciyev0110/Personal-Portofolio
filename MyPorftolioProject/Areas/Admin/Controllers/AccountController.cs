using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyPorftolioProject.Models;
using MyPorftolioProject.ViewModel;

namespace MyPorftolioProject.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        DB_A4653D_panah01Entities db = new DB_A4653D_panah01Entities();

        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admins admins)
        {
            if (db.Admins.Count(u => u.Email == admins.Email) == 1)
            {

                if (Crypto.VerifyHashedPassword(db.Admins.First(u => u.Email == admins.Email).Password, admins.Password))
                {
                   
                    Session["Admin"] = db.Admins.First(u => u.Email == admins.Email);

                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {
                    ModelState.AddModelError("Loginerror", "Username  or  password is wrong");
                }

            }
            else
            {
                ModelState.AddModelError("Loginerror", "Username  or  password is wrong");

            }

            return View(admins);

        }
    }
}