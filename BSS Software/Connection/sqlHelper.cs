using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BSSSoftware.Connection
{
    public class sqlHelper
    {
        SqlConnection cn;

        public sqlHelper(string connectionstring)
        {
            cn = new SqlConnection(connectionstring);
        }
        public bool IsConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
