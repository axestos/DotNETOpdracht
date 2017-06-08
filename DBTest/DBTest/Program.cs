using System;
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
            Console.Write(con.PasswordCorrect("Kevin", "Nivek"));
            Console.ReadLine();
        }
    }
}
