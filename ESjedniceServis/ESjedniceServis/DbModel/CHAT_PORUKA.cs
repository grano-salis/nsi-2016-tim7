namespace ESjedniceServis.DbModel
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NSI09.CHAT_PORUKA")]
    public partial class CHAT_PORUKA
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public Int32 ID { get; set; }

        public int UCESNIK_ID { get; set; }

        [Required]
        [StringLength(300)]
        public string PORUKA { get; set; }

        public DateTime VRIJEME { get; set; }

        public int STAVKA_DNEVNOG_REDA_ID { get; set; }
        [JsonIgnore]
        public STAVKA_DNEVNOG_REDA STAVKA_DNEVNOG_REDA { get; set; }
       
        public virtual UCESNIK UCESNIK { get; set; }
    }
}
