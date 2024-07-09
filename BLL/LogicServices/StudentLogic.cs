using BOL.DatabaseEntites;
using DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.LogicServices
{
    public class StudentLogic : IStudentLogic
    {
        public readonly IStudentDataDAL _studentDataDAL;
        public StudentLogic(IStudentDataDAL studentDataDAL)
        {
            this._studentDataDAL = studentDataDAL;
        }
        public List<Student> GetStudentListLogic()
        {
            List<Student> result = new List<Student> ();

            result = _studentDataDAL.GetStudentListDAL();

            return result;
        }
        public string SaveStudentRecordList(Student FormData)
        {
            string result = string.Empty;
            if (String.IsNullOrWhiteSpace(FormData.First_Name) || String.IsNullOrWhiteSpace(FormData.Last_Name) || String.IsNullOrWhiteSpace(FormData.Email))
            {
                result = "Please Fill all the Fields!";
            }
            _studentDataDAL.SaveStudentRecordDAL(FormData);
            return result;
        }
        public Student GetStudentById(int id)
        {
            return _studentDataDAL.GetStudentById(id);
        }
        public string EditStudentRecordList(Student FormData)
        {
            string result = string.Empty;
            _studentDataDAL.EditStudentRecordDAL(FormData);
            return result;
        }
        public bool DeleteStudentById(int id)
        {
            return _studentDataDAL.DeleteStudentByIdDAL(id);
        }

    }
}
