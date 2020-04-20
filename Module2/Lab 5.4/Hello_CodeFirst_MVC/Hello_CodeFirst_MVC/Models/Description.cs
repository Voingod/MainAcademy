using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hello_CodeFirst_MVC.Models
{
    [Table("Descriptions")] // Table name
    public class Description
    {
        [Key]
        public int DescriptionID { get; set; }

        [ForeignKey("Picture")]
        public int PictureID { get; set; }
        public string DescriptionText { get; set; }

        // This will keep track of the Picture this Description belong too
        public virtual Picture Picture { get; set; }
    }
}