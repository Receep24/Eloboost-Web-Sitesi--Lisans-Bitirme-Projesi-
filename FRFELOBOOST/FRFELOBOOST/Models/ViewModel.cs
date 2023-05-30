using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FRFELOBOOST.Models
{
    public class ViewModel
    {
        public List<Comments> Comments { get; set; }
        public List<Customers> Customers { get; set; }
        public List<Games> Games { get; set; }
       public List<Elooboster> Elooboster { get; set; }
        public List<Adverts> Adverts { get; set; }
        public List<Ranks> Ranks { get; set; }
        public List<Genders> Genders { get; set; }
        public List<Admins> Admins { get; set; }
        public Adverts adverts { get; set; }
        
    }
}