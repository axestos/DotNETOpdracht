namespace DBTest
{
    internal class Item
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