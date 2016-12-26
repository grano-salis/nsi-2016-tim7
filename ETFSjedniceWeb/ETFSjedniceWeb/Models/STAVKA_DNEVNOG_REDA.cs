using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class STAVKA_DNEVNOG_REDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAVKA_DNEVNOG_REDA()
        {
            this.CHAT_PORUKA = new HashSet<CHAT_PORUKA>();
            this.GLAS = new HashSet<GLAS>();
        }

        public int ID { get; set; }
        public decimal REDNI_BROJ { get; set; }
        public string NASLOV { get; set; }
        public string OPIS { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAT_PORUKA> CHAT_PORUKA { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GLAS> GLAS { get; set; }
        [JsonIgnore]
        public virtual SJEDNICA SJEDNICA { get; set; }
        [JsonIgnore]
        public virtual STATUS_STAVKE_DNEVNOG_REDA STATUS_STAVKE_DNEVNOG_REDA { get; set; }
    }
}