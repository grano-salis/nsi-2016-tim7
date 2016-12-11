using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class STATUS_UCESNIKA
    {
        public STATUS_UCESNIKA()
        {
            this.UCESNIKs = new HashSet<UCESNIK>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }

        public virtual ICollection<UCESNIK> UCESNIKs { get; set; }
    }
}