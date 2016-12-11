﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class ZAPISNIK
    {
        public ZAPISNIK()
        {
            this.SJEDNICAs = new HashSet<SJEDNICA>();
        }
    
        public int ID { get; set; }
        public string TEKST { get; set; }
    
        public virtual PRILOG PRILOG { get; set; }
        public virtual ICollection<SJEDNICA> SJEDNICAs { get; set; }
        public virtual SJEDNICA SJEDNICA { get; set; }
        public virtual UCESNIK UCESNIK { get; set; }
    }
}