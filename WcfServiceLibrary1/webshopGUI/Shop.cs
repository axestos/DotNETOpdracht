using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace webshopGUI
{
    public partial class Shop : Form
    {
        IUserService userService = new UserService();
        IRefreshService shopRefreshService = new RefreshService();
        IBuyService buy = new BuyService();
        IGetItemIdService itemService = new GetItemIdService();
        User loggedInUser = null;

        public Shop(string username)
        {
            InitializeComponent();
            loggedInUser = userService.GetUser(username);
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItem != null)
            {

                Item item = ForItemName(productsListBox.SelectedItem.ToString());

                if(item == null)
                {
                    errorShop.ForeColor = Color.Red;
                    errorShop.Text = "This item has been sold out.";
                    return;
                }

                int item_id = itemService.GetItemID(item.itemName);
                if(buy.BuyItem(loggedInUser.userId, item_id))
                {
                    AfterPurchase();
                    errorShop.Text = "Product succesfully bought.";
                    errorShop.ForeColor = Color.Green;
                    return;
                }

                if(loggedInUser.balance < item.price)
                {
                    errorShop.ForeColor = Color.Red;
                    errorShop.Text = "You don't have enough money to do that.";
                    return;
                }


                errorShop.ForeColor = Color.Red;
                errorShop.Text = "This product is currently not available.";
                return;
            }
            errorShop.ForeColor = Color.Red;
            errorShop.Text = "Please select a product";
        }

        private void Shop_Load(object sender, EventArgs e)
        {
           eurosLabel.Text = loggedInUser.balance.ToString();
           foreach(Item item in loggedInUser.inventory)
            {
                inventoryListBox.Items.Add(item.itemName + ", " + item.amount);

            }

           foreach(Item item in shopRefreshService.GetStoreItems())
            {
                productsListBox.Items.Add("(" + item.amount + "x) : " + item.itemName + ": " + item.price);
            }



        }

        private Item ForItemName(string itemName)
        {
            
                string i = itemName.Split(':')[1].Trim();

                //Console.WriteLine(i);


                foreach(Item x in shopRefreshService.GetStoreItems())
                {
                    if (i == x.itemName)
                        return x;
                }
            return null;
        }

        private void productsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            productsListBox.Items.Clear();
            foreach (Item item in shopRefreshService.GetStoreItems())
            {
                Console.WriteLine("Cleared");
                productsListBox.Items.Add("(" + item.amount + "x) : " + item.itemName + ": " + item.price);
            }
        }

        private void AfterPurchase()
        {
            inventoryListBox.Items.Clear();
            productsListBox.Items.Clear();
            loggedInUser = userService.GetUser(loggedInUser.username);
            eurosLabel.Text = loggedInUser.balance.ToString();

            foreach (Item item in shopRefreshService.GetStoreItems())
            {
                productsListBox.Items.Add("(" + item.amount + "x) : " + item.itemName + ": " + item.price);
            }

            foreach (Item item in loggedInUser.inventory)
            {
                inventoryListBox.Items.Add(item.itemName + ", " + item.amount);

            }


        }
    }
}
