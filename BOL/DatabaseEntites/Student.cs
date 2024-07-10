using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.DatabaseEntites
{
    public class Student
    {
        public int StudentId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Subjects { get; set; }
        public string Details { get; set; }
    }
}
