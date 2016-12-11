using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class UCESNIK
    {
        public UCESNIK()
        {
            this.CHAT_PORUKA = new HashSet<CHAT_PORUKA>();
            this.GLAS = new HashSet<GLA>();
            this.ZAPISNIKs = new HashSet<ZAPISNIK>();
        }

        public int ID { get; set; }
        public Nullable<decimal> UPOSLENIK_ID { get; set; }

        public virtual ICollection<CHAT_PORUKA> CHAT_PORUKA { get; set; }
        public virtual ICollection<GLA> GLAS { get; set; }
        public virtual SJEDNICA SJEDNICA { get; set; }
        public virtual STATUS_UCESNIKA STATUS_UCESNIKA { get; set; }
        public virtual TIP_UCESNIKA TIP_UCESNIKA { get; set; }
        public virtual ICollection<ZAPISNIK> ZAPISNIKs { get; set; }
    }
}