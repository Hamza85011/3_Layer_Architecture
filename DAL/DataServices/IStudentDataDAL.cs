using BOL.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{
    public interface IStudentDataDAL
    {
        List<Student> GetStudentListDAL();
        string SaveStudentRecordDAL(Student FormData);
        string EditStudentRecordDAL(Student FormData);
        Student GetStudentById(int id);
    }
}
