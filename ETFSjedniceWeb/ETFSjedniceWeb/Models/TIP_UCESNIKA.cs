﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{

    [Table("NSI09.TIP_UCESNIKA")]
    public partial class TIP_UCESNIKA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIP_UCESNIKA()
        {
            UCESNIK = new HashSet<UCESNIK>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAZIV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Newtonsoft.Json.JsonIgnore]

        public ICollection<UCESNIK> UCESNIK { get; set; }
    }
}