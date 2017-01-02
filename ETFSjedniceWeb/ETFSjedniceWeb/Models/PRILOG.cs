using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETFSjedniceWeb.Models
{

    [Table("NSI09.PRILOG")]
    public partial class PRILOG
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAZIV { get; set; }

        [StringLength(50)]
        public string CONTENT_TYPE { get; set; }

        public byte[] SADRZAJ { get; set; }

        public int SJEDNICA_ID { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public SJEDNICA SJEDNICA { get; set; }
    }
}