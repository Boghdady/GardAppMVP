using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardAppUsingMVP.src.logic.services
{
   static class SQLHelpers  
    {

        static public SqlCommand command;

        private static SqlConnection getConnectionString() 
        {
            // Should be gotten from config in secure storage.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-M1OQ9P1\SQLEXPRESS";
            builder.InitialCatalog = "GardDB";
            builder.IntegratedSecurity = true;
            return new SqlConnection(builder.ConnectionString);
        }

        static public bool ExecuteNonQuerySP(string spName,Action method )
        {   
                using(SqlConnection Connection = getConnectionString())
                {
                    try
                    {
                        // Create command from SP
                        command = new SqlCommand(spName, Connection);
                        // Function to add SP params
                        method.Invoke();
                        command.CommandType = CommandType.StoredProcedure;


                        Connection.Open();
                        command.ExecuteNonQuery();

                        Connection.Close();
                        return true;
                     }
                    catch (SqlException ex)
                    {
                        Connection.Close();
                        Console.WriteLine("SQL Error" + ex.Message.ToString());
                        return false;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }


            

           
            
        }

        static public DataTable ExcuteSelectSp(string spName, Action method)
        {
       
                DataTable dataTable = new DataTable();

                using (SqlConnection Connection = getConnectionString())
                {
                    try {
                        // Open connection
                        Connection.Open();

                        // Create command from params / SP
                        SqlCommand cmd = new SqlCommand(spName, Connection);

                        // Add parameters
                        method.Invoke();
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Make datatable for conversion
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dataTable);
                        da.Dispose();

                        // Close connection
                        Connection.Close();
                        return dataTable;     
                }
                catch (SqlException ex)
                {
                    Connection.Close();
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return null;
                }
                finally
                {
                    Connection.Close();
                }
            }
        }
    }
}
