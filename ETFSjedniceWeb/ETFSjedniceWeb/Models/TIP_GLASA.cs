using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class TIP_GLASA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIP_GLASA()
        {
            this.GLAS = new HashSet<GLAS>();
        }

        public int ID { get; set; }
        public string NAZIV { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GLAS> GLAS { get; set; }
    }
}