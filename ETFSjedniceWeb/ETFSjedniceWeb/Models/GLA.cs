using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class GLA
    {
        public int ID { get; set; }

        public virtual STAVKA_DNEVNOG_REDA STAVKA_DNEVNOG_REDA { get; set; }
        public virtual TIP_GLASA TIP_GLASA { get; set; }
        public virtual UCESNIK UCESNIK { get; set; }
    }
}