using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserInventoryService" in both code and config file together.
    public class UserInventoryService : IUserInventoryService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public IEnumerable<Item> UserInventory(int user_id)
        {
            return con.getInventoryItems(user_id).AsEnumerable();
        }
    }
}
