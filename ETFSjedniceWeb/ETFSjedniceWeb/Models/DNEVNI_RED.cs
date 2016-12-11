using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class DNEVNI_RED
    {
        public DNEVNI_RED()
        {
            this.STAVKA_DNEVNOG_REDA = new HashSet<STAVKA_DNEVNOG_REDA>();
        }

        public int ID { get; set; }

        public virtual ICollection<STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }
        public virtual SJEDNICA SJEDNICA { get; set; }
    }
}