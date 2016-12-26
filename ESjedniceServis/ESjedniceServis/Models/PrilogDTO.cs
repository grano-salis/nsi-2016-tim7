using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESjedniceServis.Models
{
    public class PrilogDTO
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string ContentType { get; set; }
        [Required]
        public HttpPostedFileBase Sadrzaj { get; set; }

    
    


    
    }
}