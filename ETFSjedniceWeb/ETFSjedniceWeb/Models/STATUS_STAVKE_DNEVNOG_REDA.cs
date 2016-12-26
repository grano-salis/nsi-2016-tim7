using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class STATUS_STAVKE_DNEVNOG_REDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATUS_STAVKE_DNEVNOG_REDA()
        {
            this.STAVKA_DNEVNOG_REDA = new HashSet<STAVKA_DNEVNOG_REDA>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }
    }
}