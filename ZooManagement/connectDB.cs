using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ZooManagement
{
    internal class connectDB
    {
        public static SqlConnection ConnectZooDB()
        {
            string server = @"(localdb)\MSSQLLocalDB";
            string db = "ZooDB";
            string strCon = string.Format("Data Source={0};Initial Catalog={1};" + "Integrated Security=True;Encrypt=False;", server, db);

            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();
            return conn;
        }
    }
}
