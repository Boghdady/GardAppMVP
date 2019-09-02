using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardAppUsingMVP.src.views.interfaces
{
   public interface ItemInterface
    {
        int ID { get; set; }
        String ItemName { get; set; }
        decimal ItemQty { get; set; }
    }
}
