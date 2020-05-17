using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class ClusterWoman
    {
        public byte Id { get; set; }
        public byte Cluster { get; set; }
        public string Conclusion { get; set; }
        public string Recomendation { get; set; }
        public ICollection<CardioParamResultWoman> CardioParamResultWomen { get; set; }
        public ICollection<ClusterStudent> ClusterStudents{ get; set; }
    }
}