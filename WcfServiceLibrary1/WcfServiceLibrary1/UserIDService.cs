using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserIDService" in both code and config file together.
    public class UserIDService : IUserIDService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public int GetUserID(string username)
        {
            return con.GetUserID(username);
        }
    }
}
