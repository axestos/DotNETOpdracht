using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    public class Item
    {
        public string itemName { get; set; }
        public int amount { get; set; }
        public float price { get; set; }

        public Item(string itemname, int amount, float price)
        {
            this.itemName = itemname;
            this.amount = amount;
            this.price = price;
        }

        public Item(string itemname, int amount)
        {
            this.itemName = itemname;
            this.amount = amount;
        }
        public override string ToString()
        {
            return this.itemName + ", amount: " + this.amount + " , price:  " + this.price; 
        }

    }


    
}
