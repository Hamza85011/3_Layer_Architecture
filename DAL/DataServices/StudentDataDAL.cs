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
        public string Sign_Up_DAL(UserLogin userLogin)
        {
            string result = string.Empty;
            try
            {
                using(IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
                {
                    string sql = @"Insert into User_Login (Name, UserName, Password) " +
                        "VALUES(@Name , @UserName , @Password)";
                    var parameters = new
                    {
                        userLogin.Name,
                        userLogin.UserName,
                        userLogin.Password
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
        public bool Sign_In_DAL(UserLogin userLogin)
        {
            using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
            {
                string sql = "SELECT * FROM User_Login WHERE UserName = @UserName AND Password = @Password";
                var parameters = new { UserName = userLogin.UserName, Password = userLogin.Password };
                int count = dbConnection.ExecuteScalar<int>(sql, parameters);
                return count > 0;
            }
        }
        public string SaveStudentRecordDAL(Student formData)
        {
            using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
            {
                string sql = "INSERT INTO Student (First_Name, Last_Name, Email, Age, Subjects, Details) " +
                             "VALUES (@First_Name, @Last_Name, @Email, @Age, @Subjects, @Details);";
                var result = dbConnection.Execute(sql, formData);
                return result > 0 ? "Student record saved successfully." : "Error saving student record.";
            }
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
                               Email = @Email,
                               Age = @Age,
                               Subjects = @Subjects,
                               Details = @Details
                           WHERE StudentID = @StudentID";
                    var parameters = new
                    {
                        formData.First_Name,
                        formData.Last_Name,
                        formData.Email,
                        formData.Age,
                        formData.Subjects,
                        formData.Details,
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
        public bool DeleteStudentByIdDAL(int id)
        {
            using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
            {
                string sql = "DELETE FROM Student WHERE StudentID = @StudentID";
                var parameters = new { StudentID = id };
                int rowsAffected = dbConnection.Execute(sql, parameters);
                return rowsAffected > 0;
            }
        }
        public Student GetStudentDetailsDAL(int id)
        {
            using (IDbConnection dbConnection = _dapperOrmHelper.GetDapperConnectionHelper())
            {
                string sql = "SELECT * FROM Student WHERE StudentID = @StudentID";
                var parameters = new { StudentID = id };
                return dbConnection.QuerySingleOrDefault<Student>(sql, parameters);
            }
        }
    }
}
