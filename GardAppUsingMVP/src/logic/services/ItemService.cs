using GardAppUsingMVP.src.models;
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
       

        static private void PrepareAddSP(int id , String itemName, decimal itemQTY, SqlCommand command)
        {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@ItemName", SqlDbType.Text).Value = itemName;
                    command.Parameters.Add("@qty", SqlDbType.Real).Value = itemQTY;
        }

    
        static public bool addItemService(int id, String itemName, decimal itemQTY)
        {   
            return DB.dbConnect("sp_AddItem", () => PrepareAddSP(id, itemName, itemQTY, DB.command));
        }

        static public bool deleteAllItemsService() {
            return DB.dbConnect("sp_DeleteAllItems", () => { });
        }

        static public bool getAllItems()
        {
            return DB.dbConnect("", () => { });
        }

    }
}
