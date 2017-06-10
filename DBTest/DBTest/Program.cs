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
            int user_id = con.GetUserID("Kevin");
            Console.WriteLine(con.UserBalance("Kevin"));
            IEnumerable<Item> inventory = con.getInventoryItems(user_id).AsEnumerable();
            foreach(Item i in inventory)
            {
                Console.WriteLine(i.itemname+" ("+i.amount+")");
            }
            IEnumerable<Item> store = con.getStoreItems().AsEnumerable();
            foreach(Item s in store)
            {
                Console.WriteLine(s.itemname + " amount in store: "+s.amount+" price in €:"+s.price);
            } 
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
