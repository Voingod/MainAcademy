using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class ResultViewModel
    {
        public string Conclusion { get; set; }
        public string Recomendation { get; set; }
        public string NextConclusion { get; set; }
        public string NextRecomendation{ get; set; }
    }
}