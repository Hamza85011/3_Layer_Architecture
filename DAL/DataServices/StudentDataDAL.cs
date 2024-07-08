using BOL.DatabaseEntites;
using DAL.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataServices
{

    public class StudentDataDAL : IStudentDataDAL
    {
        private readonly IDapperOrmHelper _dapperOrmHelper;

        public StudentDataDAL(IDapperOrmHelper dapperOrmHelper)
        {
            _dapperOrmHelper = dapperOrmHelper;
        }
        public  List<Student> GetStudentListDAL()
        {
           List <Student> students = new List<Student>();
            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
                {
                    string SqlQuery = "Select * from Student";
                    students = dbConnection.Query<Student>(SqlQuery , commandType: CommandType.Text ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return students;
        }
        public string SaveStudentRecordDAL(Student FormData)
        {
            string result = string.Empty;
            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
                {
                    dbConnection.Execute(@"Insert into Student(First_Name, Last_Name, Email) Values(@First_Name, @Last_Name, @Email)",
                        new
                        {
                            First_Name = FormData.First_Name, Last_Name = FormData.Last_Name, Email = FormData.Email
                        },
                        commandType: CommandType.Text);
                    result = "Saved Successfully";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
