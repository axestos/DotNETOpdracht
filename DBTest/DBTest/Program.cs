using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DBConnect con = DBConnect.DB_INSTANCE;

            con.SetNewUserBalance(1,10);
            Console.WriteLine(con.UserBalance("Kevin"));
            Console.WriteLine(con.BuyItem("Kevin", "Pear"));
            Console.WriteLine(con.UserBalance("Kevin"));

            Console.ReadLine();
        }
        private static string Reverse(string username)
        {
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
