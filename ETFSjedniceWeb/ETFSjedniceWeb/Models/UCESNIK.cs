using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    [Table("NSI09.UCESNIK")]
    public partial class UCESNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UCESNIK()
        {
            //CHAT_PORUKA = new HashSet<CHAT_PORUKA>();
            //GLAS = new HashSet<GLAS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int UPOSLENIK_ID { get; set; }

        public int SJEDNICA_ID { get; set; }

        public int TIP_UCESNIKA_ID { get; set; }

        public int STATUS_UCESNIKA_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<CHAT_PORUKA> CHAT_PORUKA { get; set; }

        public virtual CV_USER_INFO CV_USER_INFO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<GLAS> GLAS { get; set; }
        [JsonIgnore]

        public SJEDNICA SJEDNICA { get; set; }

        public virtual STATUS_UCESNIKA STATUS_UCESNIKA { get; set; }

        public virtual TIP_UCESNIKA TIP_UCESNIKA { get; set; }
    }
}