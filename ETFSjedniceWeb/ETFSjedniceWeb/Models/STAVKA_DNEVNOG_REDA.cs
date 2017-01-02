using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{
    [Table("NSI09.STAVKA_DNEVNOG_REDA")]
    public partial class STAVKA_DNEVNOG_REDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAVKA_DNEVNOG_REDA()
        {
            CHAT_PORUKA = new HashSet<CHAT_PORUKA>();
            GLAS = new HashSet<GLAS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int SJEDNICA_ID { get; set; }

        public int REDNI_BROJ { get; set; }

        [Required]
        [StringLength(20)]
        public string NASLOV { get; set; }

        [Required]
        [StringLength(300)]
        public string OPIS { get; set; }

        public int STATUS_STAVKE_DR_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAT_PORUKA> CHAT_PORUKA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GLAS> GLAS { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public SJEDNICA SJEDNICA { get; set; }

        public virtual STATUS_STAVKE_DNEVNOG_REDA STATUS_STAVKE_DNEVNOG_REDA { get; set; }
    }
}