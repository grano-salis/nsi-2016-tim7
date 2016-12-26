using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    public class UCESNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UCESNIK()
        {
            this.CHAT_PORUKA = new HashSet<CHAT_PORUKA>();
            this.GLAS = new HashSet<GLAS>();
        }

        public int ID { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAT_PORUKA> CHAT_PORUKA { get; set; }
        [JsonIgnore]
        public virtual CV_USER_INFO CV_USER_INFO { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GLAS> GLAS { get; set; }
        [JsonIgnore]
        public virtual SJEDNICA SJEDNICA { get; set; }
        [JsonIgnore]
        public virtual STATUS_UCESNIKA STATUS_UCESNIKA { get; set; }
        [JsonIgnore]
        public virtual TIP_UCESNIKA TIP_UCESNIKA { get; set; }
    }
}