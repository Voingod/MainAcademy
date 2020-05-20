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
        [Display(Name = "Факультет")]
        public int DepartmentId { get; set; }
        [Display(Name = "Вид спорта")]
        public int TypeOfSportId { get; set; }
        [Display(Name ="Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Курс")]
        public byte Course { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Пол")]
        public byte Sex { get; set; }
        public ICollection<ClusterStudent> ClusterStudents { get; set; }
        public ICollection<CardioParam> CardioParams { get; set; }
        public Student()
        {
            int id = (int)SportID.None;

            DepartmentId = id;
            TypeOfSportId = id;
        }
    }

    
}