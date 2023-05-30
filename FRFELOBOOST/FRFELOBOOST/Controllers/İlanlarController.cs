using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FRFELOBOOST.Models;

namespace FRFELOBOOST.Controllers
{
    public class İlanlarController : Controller
    {
        
        public ActionResult Index()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Elooboster = db.Elooboster.ToList();
            vm.Adverts = db.Adverts.ToList();
            vm.Games = db.Games.ToList();
            vm.Ranks = db.Ranks.ToList();
            return View(vm);
        }
        public ActionResult MusteriIndex()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Elooboster = db.Elooboster.ToList();
            vm.Adverts = db.Adverts.ToList();
            vm.Games = db.Games.ToList();
            vm.Ranks = db.Ranks.ToList();
            return View(vm);
        }
    }
}