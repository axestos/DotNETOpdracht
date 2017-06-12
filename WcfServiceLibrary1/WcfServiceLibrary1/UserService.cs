using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public User GetUser(string username)
        {
            User user = new User(con.GetUserID(username));
            user.username = username;
            user.balance = con.UserBalance(user.userId);
            user.inventory = con.getInventoryItems(user.userId);

            return user;



        }
    }
}
