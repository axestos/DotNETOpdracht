using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetUserBalanceService" in both code and config file together.
    public class GetUserBalanceService : IGetUserBalanceService
    {
        DBConnect con = DBConnect.DB_INSTANCE;

        public float GetBalance(string username)
        {
            return con.UserBalance(username);
        }
    }
}
