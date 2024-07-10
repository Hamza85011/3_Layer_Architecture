using BOL.DatabaseEntites;
using DAL.DataServices;
using Microsoft.SqlServer.Server;
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
        public string Sign_Up_BLL(UserLogin userLogin)
        {
            string result = string.Empty;
            if (String.IsNullOrWhiteSpace(userLogin.Name) || String.IsNullOrWhiteSpace(userLogin.UserName) || String.IsNullOrWhiteSpace(userLogin.Password))
            {
                result = "Please Fill all the Fields!";
            }
            _studentDataDAL.Sign_Up_DAL(userLogin);
            return result;
        }
        public bool Sign_In_BLL(UserLogin userLogin)
        {
            if (String.IsNullOrWhiteSpace(userLogin.UserName) || String.IsNullOrWhiteSpace(userLogin.Password))
            {
                return false;
            }
            return _studentDataDAL.Sign_In_DAL(userLogin);
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
            if (String.IsNullOrWhiteSpace(FormData.First_Name) || String.IsNullOrWhiteSpace(FormData.Last_Name) || String.IsNullOrWhiteSpace(FormData.Email) || int.IsPositive(FormData.Age) || String.IsNullOrWhiteSpace(FormData.Subjects) || String.IsNullOrWhiteSpace(FormData.Details))
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
        public Student GetStudentDetails(int id)
        {
            return _studentDataDAL.GetStudentDetailsDAL(id);
        }
    }
}
