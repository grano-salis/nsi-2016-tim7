using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class PRILOG
    {
        public int ID { get; set; }
        public string NAZIV { get; set; }
        public string CONTENT_TYPE { get; set; }
        public byte[] SADRZAJ { get; set; }
        [JsonIgnore]
        public virtual SJEDNICA SJEDNICA { get; set; }
    }
}