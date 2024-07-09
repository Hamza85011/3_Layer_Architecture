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
                    string sql = @"INSERT INTO Student (First_Name, Last_Name, Email) 
                           VALUES (@First_Name, @Last_Name, @Email)";
                    var parameters = new
                    {
                        FormData.First_Name,
                        FormData.Last_Name,
                        FormData.Email
                    };

                    dbConnection.Execute(sql, parameters, commandType: CommandType.Text);
                    result = "Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
            }
            return result;
        }
        public Student GetStudentById(int id)
        {
            using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
            {
                string sql = "SELECT * FROM Student WHERE StudentID = @StudentID";
                var parameters = new { StudentID = id };
                return dbConnection.QuerySingleOrDefault<Student>(sql, parameters);
            }
        }
        public string EditStudentRecordDAL(Student formData)
        {
            string result = string.Empty;
            try
            {
                using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
                {
                    string sql = @"UPDATE Student 
                           SET First_Name = @First_Name, 
                               Last_Name = @Last_Name, 
                               Email = @Email
                           WHERE StudentID = @StudentID";
                    var parameters = new
                    {
                        formData.First_Name,
                        formData.Last_Name,
                        formData.Email,
                        formData.StudentId
                    };

                    dbConnection.Execute(sql, parameters, commandType: CommandType.Text);
                    result = "Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
            }
            return result;
        }


    }
}
