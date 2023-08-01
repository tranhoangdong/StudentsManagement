using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class DBConection
    {
        string strCon; 
            public DBConection()
        {
            strCon = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }

        internal SqlConnection getConnection()
        {
            throw new NotImplementedException();
        }
    }
}