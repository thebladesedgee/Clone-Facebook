using facebook.Models;
using facebook.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace facebook.Controllers
{
    public class LoginController : Controller
    {

       private DatabaseContext db = new DatabaseContext();
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Login(KişiselDatalar data)
        {
            if (ModelState.IsValid)
            {
                db.data.Add(data);
                db.SaveChanges();
                return RedirectToAction("LoginScreen");
            }
            return View();
        }
        [Authorize]
        public ActionResult ShowData()
        {
            var listele = db.data.ToList();
            return View(listele);
        }

        public ActionResult Update(int? id)
        {

            KişiselDatalar kd = db.data.Find(id);
            if (kd == null)
            {
                return HttpNotFound();
            }
            return View(kd);
        }
        [HttpPost]
        public ActionResult Update(KişiselDatalar data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowData");
            }
        
            return View(data);
        }
        public ActionResult Delete(int? id)
        {

            KişiselDatalar kdelete = db.data.Find(id);
            if (kdelete == null)
            {
                return HttpNotFound();
            }
            db.data.Remove(kdelete);
            db.SaveChanges();

            return RedirectToAction("ShowData");
           
        }


        public ActionResult LoginScreen()
        {

            return View();
        }

        [HttpPost]

        public ActionResult LoginScreen(KişiselDatalar kd)
        {
           DatabaseContext dbc = new DatabaseContext();
            var admin = dbc.data.FirstOrDefault(x => x.e_mail == kd.e_mail && x.password == kd.password);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.e_mail, false);
                Session["e_mail"] = admin.e_mail;
                Session["password"] = admin.password;
                return RedirectToAction("ShowData");

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

  
 

    }
}