using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class UserCardioViewModel
    {

        public double ADP { get; set; }
        public double ASP { get; set; }
        public double HR { get; set; }
        public byte Minute { get; set; }
        public byte ClusterWomanId { get; set; }
        public double Dist { get; set; }
        public byte NextClusterWomanId { get; set; }
        public double NextDist { get; set; }
        public string StudentId { get; set; }

    }
}