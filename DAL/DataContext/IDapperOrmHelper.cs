using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public interface IDapperOrmHelper
    {
        IDbConnection GetDapperConnectionHelper();
    }
}
