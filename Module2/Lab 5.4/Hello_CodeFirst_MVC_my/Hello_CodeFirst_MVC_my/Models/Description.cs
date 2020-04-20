using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hello_CodeFirst_MVC_my.Models
{
    [Table("Description")]
    public class Description
    {
        [Key]
        public int DescriptionID { get; set; }
        [ForeignKey("Picture")]
        public int PictureID { get; set; }
        public string DescriptionText { get; set; }
        public virtual Picture Picture { get; set; }
    }
}