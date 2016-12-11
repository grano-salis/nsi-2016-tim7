using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class STAVKA_DNEVNOG_REDA
    {
        public STAVKA_DNEVNOG_REDA()
        {
            this.GLAS = new HashSet<GLA>();
        }

        public int ID { get; set; }
        public decimal REDNI_BROJ { get; set; }
        public string NASLOV { get; set; }
        public string OPIS { get; set; }

        public virtual DNEVNI_RED DNEVNI_RED { get; set; }
        public virtual ICollection<GLA> GLAS { get; set; }
        public virtual STATUS_STAVKE_DNEVNOG_REDA STATUS_STAVKE_DNEVNOG_REDA { get; set; }
    }
}