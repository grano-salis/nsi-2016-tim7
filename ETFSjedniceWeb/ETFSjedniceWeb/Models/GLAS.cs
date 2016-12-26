using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class GLAS
    {
        public int ID { get; set; }
        [JsonIgnore]
        public virtual STAVKA_DNEVNOG_REDA STAVKA_DNEVNOG_REDA { get; set; }
        [JsonIgnore]
        public virtual TIP_GLASA TIP_GLASA { get; set; }
        [JsonIgnore]
        public virtual UCESNIK UCESNIK { get; set; }
    }
}