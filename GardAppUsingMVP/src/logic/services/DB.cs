using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardAppUsingMVP.src.logic.services
{
   static class DB
    {
        static private SqlConnection sqlConnection;
        static public SqlCommand command;

       static public int dbConnect(string spName,Action method)
        {
            try
            {
                sqlConnection = new SqlConnection(@"Data Source=DESKTOP-M1OQ9P1\SQLEXPRESS;Initial Catalog=GardDB;Integrated Security=True");
                command = new SqlCommand(spName, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

               
            
                method.Invoke();
                sqlConnection.Open();
                return command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
