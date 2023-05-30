using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FRFELOBOOST.Models;

namespace FRFELOBOOST.Controllers
{
    public class Tft_ilanController : Controller
    {
        
        public ActionResult Tft_ilan()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Elooboster = db.Elooboster.ToList();
            vm.Games = db.Games.ToList();
            vm.Adverts = db.Adverts.ToList();
            return View(vm);
            
        }
        public ActionResult MusteriTft_ilan()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Elooboster = db.Elooboster.ToList();
            vm.Games = db.Games.ToList();
            vm.Adverts = db.Adverts.ToList();
            return View(vm);

        }
    }
}