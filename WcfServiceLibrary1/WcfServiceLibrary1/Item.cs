using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    public class Item
    {
        private string itemname;
        private int amount;
        private float price;
        public Item(string itemname, int amount, float price)
        {
            this.itemname = itemname;
            this.amount = amount;
            this.price = price;
        }

        public Item(string itemname, int amount)
        {
            this.itemname = itemname;
            this.amount = amount;
        }

    }
}
