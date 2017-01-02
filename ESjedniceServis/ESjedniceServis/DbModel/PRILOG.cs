namespace ESjedniceServis.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
