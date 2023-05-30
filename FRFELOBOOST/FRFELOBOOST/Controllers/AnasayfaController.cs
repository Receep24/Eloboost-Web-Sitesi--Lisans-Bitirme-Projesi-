using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FRFELOBOOST.Models;

namespace FRFELOBOOST.Controllers
{
    public class AnasayfaController : Controller
    {
        
        
        public ActionResult Index()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Comments = db.Comments.ToList();
            vm.Customers = db.Customers.ToList();
            vm.Games = db.Games.ToList();
           
           
            return View((vm));
            
        }
        public ActionResult MusteriIndex()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Comments = db.Comments.ToList();
            vm.Customers = db.Customers.ToList();
            vm.Games = db.Games.ToList();


            return View((vm));

        }
        public ActionResult EloboosterIndex()
        {
            FRF_ELOBOOSTEntities db = new FRF_ELOBOOSTEntities();
            ViewModel vm = new ViewModel();
            vm.Comments = db.Comments.ToList();
            vm.Customers = db.Customers.ToList();
            vm.Games = db.Games.ToList();


            return View((vm));

        }
    }
}