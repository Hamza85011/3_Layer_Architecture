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
                    string SqlQuery = "Select * from Students";
                    students = dbConnection.Query<Student>(SqlQuery , commandType: CommandType.Text ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return students;
        }
    }
}
