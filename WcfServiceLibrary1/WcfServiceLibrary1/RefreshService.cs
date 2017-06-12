using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RefreshService" in both code and config file together.
    public class RefreshService : IRefreshService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public IEnumerable<Item> GetStoreItems()
        {
            return con.getStoreItems().AsEnumerable();

        }
    }
}
