using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class CHAT_PORUKA
    {
        public int ID { get; set; }
        public string PORUKA { get; set; }
        public System.DateTime VRIJEME { get; set; }

        public virtual UCESNIK UCESNIK { get; set; }
    }
}