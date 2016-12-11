using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class PRILOG
    {
        public PRILOG()
        {
            this.ZAPISNIKs = new HashSet<ZAPISNIK>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }
        public string CONTENT_TYPE { get; set; }
        public byte[] SADRZAJ { get; set; }

        public virtual ICollection<ZAPISNIK> ZAPISNIKs { get; set; }
    }
}