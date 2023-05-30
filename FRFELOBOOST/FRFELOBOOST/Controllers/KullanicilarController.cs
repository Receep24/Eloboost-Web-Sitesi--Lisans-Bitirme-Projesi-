using FRFELOBOOST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FRFELOBOOST.Controllers
{
    
    public class KullanicilarController : Controller
    {
        FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
        [HttpGet]
       
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users k)
        {
            var kullanici = db.Users.FirstOrDefault(x => x.username == k.username && x.password == k.password);
            if (kullanici != null)
            {
                if (kullanici.usertype == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(k.username, false);
                    return RedirectToAction("Index", "Admins");
                }
                else if (kullanici.usertype == "Musteri")
                {
                    FormsAuthentication.SetAuthCookie(k.username, false);
                    return RedirectToAction("MusteriIndex", "Anasayfa");
                }
                else if (kullanici.usertype == "Elobooster")
                {
                    FormsAuthentication.SetAuthCookie(k.username, false);
                    return RedirectToAction("EloboosterCreate", "Adverts");
                }
            }
                ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
                return View();
            }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}