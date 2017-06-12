using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    public class User
    {
        public int userId { get; }
        public string username { get; set; }
        public float balance { get; set; }
        public IEnumerable<Item> inventory { get; set; }


        public User(string username, float balance, IEnumerable<Item> inventory) 
        {
            this.username = username;
            this.balance = balance;
            this.inventory = inventory;
        }

        public User(int id)
        {
            this.userId = id;
        }




    }
}
