using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegisterService" in both code and config file together.
    public class RegisterService : IRegisterService
    {
        DBConnect con = new DBConnect();
        public string RegisterUser(string username) {

            if (!con.DoesUserExist(username))
            {
                string password = Reverse(username);
                con.InsertNewUser(username, password);
                string newUser = "User: " + username + " your password is: " + password;
                return newUser;
            }
            else
            {
                return "This username already exists, please try again.";

            }

        }

        public static string Reverse(string username)
        {
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
