using BOL.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.CommonEntites
{
    public class StudentModule
    {
        public List<Student>? StudentList { get; set; }
        public List<Courses>? CoursesList{ get; set; }
    }
}
