using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hello_CodeFirst_MVC_my.Models
{
    [Table("Pictures")]
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }
        public string PictureName { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }
    }
}