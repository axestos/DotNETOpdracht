using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogInService" in both code and config file together.
    public class LogInService : ILogInService
    {
        DBConnect con = new DBConnect();
        public bool LogIn(string username, string password)//Moet straks in applicatie showen dat inloggen mislukt is. Dus als hier false uit komt dat het inloggen niet mogelijk was.
        {
            if (con.DoesUserExist(username))//True, user does exist
            {
                return con.PasswordCorrect(username, password);
            }
            else
            {
                return false;
            }
            }
    }
}
