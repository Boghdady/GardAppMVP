using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardAppUsingMVP.src.logic.services
{
   static class ItemService
    {

       static private SqlConnection sqlConnection;

        static public int addItem(int id , String itemName, decimal itemQTY)
        {
            
            try
            {
                sqlConnection = new SqlConnection(@"Data Source=DESKTOP-M1OQ9P1\SQLEXPRESS;Initial Catalog=GardDB;Integrated Security=True");
                SqlCommand command = new SqlCommand("sp_AddItem", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@ItemName", SqlDbType.Text).Value = itemName;
                command.Parameters.Add("@qty", SqlDbType.Real).Value = itemQTY;
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

        static void updateItem(int id, String itemName, decimal itemQTY)
        {

        }

        static void deleteItem()
        {

        }
    }
}
