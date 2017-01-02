using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{

    [Table("NSI09.GLAS")]
    public partial class GLAS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int STAVKA_DNEVNOG_REDA_ID { get; set; }

        public int TIP_GLASA_ID { get; set; }

        public int UCESNIK_ID { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public STAVKA_DNEVNOG_REDA STAVKA_DNEVNOG_REDA { get; set; }

        public virtual TIP_GLASA TIP_GLASA { get; set; }

        public virtual UCESNIK UCESNIK { get; set; }
    }
}