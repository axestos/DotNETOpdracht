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
            
            DBConnect con = new DBConnect();

            Console.WriteLine(con.BuyItem("Kevin", "Pear"));

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
