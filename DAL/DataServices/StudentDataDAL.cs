using BOL.DatabaseEntites;
using DAL.DataContext;
using System;
using System.Collections.Generic;
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

        }
    }
}
