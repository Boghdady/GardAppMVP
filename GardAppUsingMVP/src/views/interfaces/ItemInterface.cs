using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GardAppUsingMVP.src.views.interfaces
{
   public interface ItemInterface
    {
        int ID { get; set; }
        string ItemName { get; set; }
        decimal ItemQty { get; set; }
        object DgvDataSource { get; set;}
        object CbxDataSource  { get; set;}
        string DisplayMember { get; set; }
        string ValueMember { get; set; }
    }
}
