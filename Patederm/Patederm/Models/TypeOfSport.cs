using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class TypeOfSport
    {
        public int Id { get; set; }
        public string TypeOfSportName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}