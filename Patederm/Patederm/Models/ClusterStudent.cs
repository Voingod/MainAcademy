using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class ClusterStudent
    {
        public int Id { get; set; }
        public byte ClusterWomanId { get; set; }
        public byte NextClusterWomanId { get; set; }
        public string StudentId { get; set; }
        public double Dist { get; set; }
        public double NextDist { get; set; }
        public ICollection<CardioParam> CardioParams{ get; set; }
    }
}