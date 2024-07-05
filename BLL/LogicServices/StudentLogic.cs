﻿using BOL.DatabaseEntites;
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
    }
}
