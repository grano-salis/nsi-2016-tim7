using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class SJEDNICA
    {
        public SJEDNICA()
        {
            this.DNEVNI_RED = new HashSet<DNEVNI_RED>();
            this.SJEDNICA1 = new HashSet<SJEDNICA>();
            this.UCESNIKs = new HashSet<UCESNIK>();
            this.ZAPISNIKs = new HashSet<ZAPISNIK>();
        }

        public int ID { get; set; }
        public System.DateTime DATUM_ODRZAVANJA_OD { get; set; }
        public Nullable<System.DateTime> DATUM_ODRZAVANJA_DO { get; set; }
        public string NAZIV { get; set; }
        public Nullable<decimal> DNEVNI_RED_ID { get; set; }
        public string SALA { get; set; }

        public virtual ICollection<DNEVNI_RED> DNEVNI_RED { get; set; }
        public virtual ZAPISNIK ZAPISNIK { get; set; }
        public virtual ICollection<SJEDNICA> SJEDNICA1 { get; set; }
        public virtual SJEDNICA SJEDNICA2 { get; set; }
        public virtual ICollection<UCESNIK> UCESNIKs { get; set; }
        public virtual ICollection<ZAPISNIK> ZAPISNIKs { get; set; }
    }
}