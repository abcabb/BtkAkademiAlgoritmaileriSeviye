using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTypes
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GPA { get; set; }

        public Student(int id, string name, string gpa)
        {
            ID = id;
            Name = name;
            GPA = gpa;
        }

        public override string ToString()
        {
            return $"{Name} - {GPA} - {ID}";
        }
    }
}
