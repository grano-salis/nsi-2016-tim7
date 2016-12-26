using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public  class SJEDNICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SJEDNICA()
        {
            this.PRILOG = new HashSet<PRILOG>();
            this.STAVKA_DNEVNOG_REDA = new HashSet<STAVKA_DNEVNOG_REDA>();
            this.UCESNIK = new HashSet<UCESNIK>();
        }

        public int ID { get; set; }
        public System.DateTime DATUM_ODRZAVANJA_OD { get; set; }
        public Nullable<System.DateTime> DATUM_ODRZAVANJA_DO { get; set; }
        public string NAZIV { get; set; }
        public string SALA { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRILOG> PRILOG { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }
        [JsonIgnore]
        public virtual STATUS_SJEDNICE STATUS_SJEDNICE { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UCESNIK> UCESNIK { get; set; }
    }
}