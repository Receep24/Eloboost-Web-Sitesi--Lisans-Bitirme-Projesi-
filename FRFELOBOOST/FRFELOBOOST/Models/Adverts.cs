//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FRFELOBOOST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adverts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adverts()
        {
            this.Meetings = new HashSet<Meetings>();
        }
    
        public int AdvertsID { get; set; }
        public Nullable<int> EloobosterID { get; set; }
        public Nullable<int> GamesID { get; set; }
        public Nullable<int> RankID { get; set; }
        public string AdvertTitle { get; set; }
        public System.DateTime AdvertDate { get; set; }
    
        public virtual Elooboster Elooboster { get; set; }
        public virtual Games Games { get; set; }
        public virtual Ranks Ranks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meetings> Meetings { get; set; }
    }
}
