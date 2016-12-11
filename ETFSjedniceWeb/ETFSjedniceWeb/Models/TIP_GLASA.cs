using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class TIP_GLASA
    {
        public TIP_GLASA()
        {
            this.GLAS = new HashSet<GLA>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }

        public virtual ICollection<GLA> GLAS { get; set; }
    }
}