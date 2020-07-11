using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class CardioParam
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public double ASP { get; set; }
        public double ADP { get; set; }
        public double HR { get; set; }
        public byte Minute { get; set; }
        public int ClusterStudentId { get; set; }

    }
}