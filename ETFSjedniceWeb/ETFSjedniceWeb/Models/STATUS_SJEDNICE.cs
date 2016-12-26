using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public  class STATUS_SJEDNICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATUS_SJEDNICE()
        {
            this.SJEDNICA = new HashSet<SJEDNICA>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJEDNICA> SJEDNICA { get; set; }
    }
}