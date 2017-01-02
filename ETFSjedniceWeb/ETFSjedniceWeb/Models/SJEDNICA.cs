using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{

    [Table("NSI09.SJEDNICA")]
    public partial class SJEDNICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SJEDNICA()
        {
            PRILOG = new HashSet<PRILOG>();
            STAVKA_DNEVNOG_REDA = new HashSet<STAVKA_DNEVNOG_REDA>();
            UCESNIK = new HashSet<UCESNIK>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
       
        public DateTime DATUM_ODRZAVANJA_OD { get; set; }

        public DateTime? DATUM_ODRZAVANJA_DO { get; set; }

        [Required]
        [StringLength(50)]
        public string NAZIV { get; set; }

        [StringLength(15)]
        public string SALA { get; set; }

        public int STATUS_SJEDNICE_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Newtonsoft.Json.JsonIgnore]
        public ICollection<PRILOG> PRILOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAVKA_DNEVNOG_REDA> STAVKA_DNEVNOG_REDA { get; set; }

        public virtual STATUS_SJEDNICE STATUS_SJEDNICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UCESNIK> UCESNIK { get; set; }
    }
}