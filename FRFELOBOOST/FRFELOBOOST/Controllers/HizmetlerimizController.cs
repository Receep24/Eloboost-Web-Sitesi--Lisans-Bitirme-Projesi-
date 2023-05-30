using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRFELOBOOST.Controllers
{
    public class HizmetlerimizController : Controller
    {
       
        public ActionResult Hizmetlerimiz()
        {
            return View();
        }
        public ActionResult MusteriHizmetlerimiz()
        {
            return View();
        }
    }
}