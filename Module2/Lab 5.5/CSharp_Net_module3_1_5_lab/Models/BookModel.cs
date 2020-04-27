using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp_Net_module3_1_5_lab.Models
{
    public class BookModel
    {
        [Required(ErrorMessage = "Error BookName")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Error Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Error Edition")]
        public string Edition { get; set; }
        [Required(ErrorMessage = "Error Publishing")]
        public string Publishing { get; set; }

    }
}