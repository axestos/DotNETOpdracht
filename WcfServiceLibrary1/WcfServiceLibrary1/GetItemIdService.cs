using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetItemIdService" in both code and config file together.
    public class GetItemIdService : IGetItemIdService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public int GetItemID(string item_name)
        {
            return con.GetItemId(item_name);
        }
    }
}
