using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp_Net_module3_1_1_lab.Models
{
    // 1) Add properties to model
    public class BookModels
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Publishing { get; set; }

    }
}