using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_WPF_stud
{
    public class Student
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public static ObservableCollection<Student> GetStudents()
        {
            ObservableCollection<Student> result = new ObservableCollection<Student>
            {
                new Student() { Name = "Andry Houp", Rate = 70 },
                new Student() { Name = "Mary First", Rate = 64 },
                new Student() { Name = "John Miller", Rate = 30 },
                new Student() { Name = "Helen Best", Rate = 0 },
                new Student() { Name = "Ivan Stown", Rate = 29 },
                new Student() { Name = "Mishel Capoa", Rate = 91 }
            };
            return result;
        }
    }
}
