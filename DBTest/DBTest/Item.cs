namespace DBTest
{
    internal class Item
    {
        public string itemname;
        public int amount;
        public float price;

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