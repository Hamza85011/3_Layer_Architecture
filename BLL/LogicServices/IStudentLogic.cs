using BOL.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public interface IStudentLogic
    {
        List<Student> GetStudentListLogic();
        string SaveStudentRecordList(Student FormData);
        string EditStudentRecordList(Student FormData);
        Student GetStudentById(int id);
        bool DeleteStudentById(int id);
        Student GetStudentDetails(int id);
        string Sign_Up_BLL(UserLogin userLogin);
        bool Sign_In_BLL(UserLogin userLogin);
    }
}
