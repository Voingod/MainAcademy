using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Patederm.Models
{
    public class Student
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public virtual AppUser User { get; set; }

        public int DepartmentId { get; set; }
        public int TypeOfSportId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public byte Course { get; set; }
        public DateTime Birthday { get; set; }
        public byte Sex { get; set; }
        public ICollection<ClusterStudent> ClusterStudents { get; set; }
        public ICollection<CardioParam> CardioParams { get; set; }
        public Student()
        {
            int id = (int)ID.None;
            DepartmentId = id;
            TypeOfSportId = id;
        }
    }

    enum ID : byte { None = 1 }
}