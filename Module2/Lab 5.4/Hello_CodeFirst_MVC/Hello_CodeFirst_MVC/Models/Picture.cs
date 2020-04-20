using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hello_CodeFirst_MVC.Models

{
        [Table("Pictures")] // Table name
        public class Picture
        {
            [Key] // Primary key
            public int PictureID { get; set; }
            public string PictureName { get; set; }
            public string Author { get; set; }
            public byte[] Image { get; set; }

            // This is to maintain the many Descriptions associated with a Picture entity
            public virtual ICollection<Description> Descriptions { get; set; }
        }
    }
