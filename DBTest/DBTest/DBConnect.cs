using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    class DBConnect
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect(string server, string database, string uid, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;
            connection = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";");
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "webwinkel";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        //if this one is called, also call the RefreshService and GetUserInventoryService to reset both fields in the application
        public bool BuyItem(string username, string item_name)//Tested
        {
            int item_id = GetItemId(item_name);
            float user_balance = UserBalance(username);
            float item_price = GetItemPrice(item_name);
            int item_amount = GetItemAmountInStore(item_id);
            int user_id = GetUserID(username);
            int inventory_id = GetInventoryID(user_id);
            bool itemInInventory = IsItemInInventory(item_id, inventory_id);
            int item_amountInventory = ItemAmountInInventory(item_id, inventory_id);
            //check if inventory item is already existant. If true amount +1, If false new Row with item.

            if (item_amount > 0)//Is the item sold out?
            {
                Console.WriteLine(item_price <= user_balance);
                if (item_price <= user_balance)//Can the user pay for the item?
                {
                    int new_item_amount = item_amount-1;
                    float new_user_balance = user_balance - item_price;
                    SetNewStoreAmount(item_id, new_item_amount);//Sets new item amount in store
                    SetNewUserBalance(user_id, new_user_balance);//Sets new userbalance

                    if (OpenConnection())
                    {
                        if (itemInInventory)//Item is already in the inventory, amount + 1
                        {
                            int new_item_inventory_amount = item_amountInventory+1;
                            MySqlCommand cmd = connection.CreateCommand();
                            cmd.CommandText = "UPDATE inventory_item SET amount = @amount WHERE item_id = @id AND inventory_id=@inv_id"; // Voorkomt SQL injectie!!!!
                            cmd.Parameters.AddWithValue("@amount", new_item_inventory_amount);
                            cmd.Parameters.AddWithValue("@id", item_id);
                            cmd.Parameters.AddWithValue("@inv_id", inventory_id);
                            cmd.ExecuteNonQuery();//Execute query
                            CloseConnection();
                        }

                        else//Item is not in the inventory
                        {
                            MySqlCommand cmd = connection.CreateCommand();
                            cmd.CommandText = "INSERT INTO inventory_item(amount,inventory_id,item_id) VALUES(1,@inv_id,@item_id)"; // Voorkomt SQL injectie!!!!
                            cmd.Parameters.AddWithValue("@inv_id", inventory_id);
                            cmd.Parameters.AddWithValue("@item_id", item_id);
                            cmd.ExecuteNonQuery();//Execute query
                            CloseConnection();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        public int GetInventoryID(int user_id)//tested
        {
            int inventory_id = 0;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM inventory WHERE user_id = @id "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@id", user_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    inventory_id = (int)reader["id"];
                }
                CloseConnection();
                return inventory_id;
            }
            return inventory_id;
        }

        public bool IsItemInInventory(int item_id, int inventory_id)//tested
        {
            bool inInventory = false;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM inventory_item WHERE inventory_id = @inv_id AND item_id = @it_id";
                cmd.Parameters.AddWithValue("@inv_id", inventory_id);
                cmd.Parameters.AddWithValue("@it_id", item_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    inInventory = true;
                }
                CloseConnection();
                return inInventory;
            }
            return inInventory;

        }


        public int ItemAmountInInventory(int item_id, int inventory_id)//Tested
        {
            int inInventory = 0;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT amount FROM inventory_item WHERE inventory_id = @inv_id AND item_id = @it_id";
                cmd.Parameters.AddWithValue("@inv_id", inventory_id);
                cmd.Parameters.AddWithValue("@it_id", item_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    inInventory = (int)reader["amount"];
                }
                CloseConnection();
                return inInventory;
            }
            return inInventory;

        }

        public void SetNewStoreAmount(int item_id, int amount)//tested
        {
            if (OpenConnection())
            {
                //Creates user
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE shop SET item_amount = @amount WHERE item_id = @id "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@id", item_id);
                cmd.ExecuteNonQuery();//Execute query
                CloseConnection();
            }

        }


        public void SetNewUserBalance(int user_id, float balance)//tested
        {
            if (OpenConnection())
            {
                //Creates user
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE user SET balance = @amount WHERE id = @id "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@amount", balance);
                cmd.Parameters.AddWithValue("@id", user_id);
                cmd.ExecuteNonQuery();//Execute query
                CloseConnection();
            }

        }


        public float GetItemPrice(string item_name)//tested
        {
            float itemprice = 0;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT price FROM item WHERE item_name = @name";
                cmd.Parameters.AddWithValue("@name", item_name);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemprice = (float)reader["price"];
                }
                CloseConnection();
                return itemprice;
            }
            return itemprice;
        }


        public int GetItemAmountInStore(int item_id)//tested
        {
            int itemamount = 0;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT item_amount FROM shop WHERE item_id = @id";
                cmd.Parameters.AddWithValue("@id", item_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemamount = (int)reader["item_amount"];
                }
                CloseConnection();
                return itemamount;
            }
            return itemamount;
        }

        public int GetItemId(string item_name)//tested
        {
            int itemid = 0;
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM item WHERE item_name = @name";
                cmd.Parameters.AddWithValue("@name", item_name);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemid = (int)reader["id"];
                }
                CloseConnection();
                return itemid;
            }
            return itemid;
        }

        public int GetUserID(string username)//Returns ID from certain username -- tested
        {
            int user_id = 0;

            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM user WHERE username = @name"; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@name", username);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user_id = (int)reader["id"];
                }
                CloseConnection();
                return user_id;//filled up or empty if none found

            }
            else
            {
                return user_id;//empty
            }

        }

        public void InsertNewUser(string username, string password)//Insert new user -- tested
        {
            if (OpenConnection())
            {
                //Creates user
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO user(username, password, balance) VALUES(@name,@password,10) "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();//Execute query
                CloseConnection();

                InsertNewInventory(username);

            }
        }

        public void InsertNewInventory(string username)//tested
        {
            int user_id = GetUserID(username);
            if (OpenConnection())
            {
                //Makes inventory for user
                MySqlCommand inv = connection.CreateCommand();
                inv.CommandText = "INSERT INTO inventory(user_id) VALUES(@user_id) ";
                inv.Parameters.AddWithValue("@user_id", user_id);
                inv.ExecuteNonQuery();
                CloseConnection();
            }
        }



        public List<Item> getStoreItems()//tested
        {
            List<Item> storeStock = new List<Item>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT shop.item_amount, item.item_name, item.price FROM shop INNER JOIN item ON shop.item_id=item.id WHERE shop.item_amount > 0 ";
            if (OpenConnection())
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string itemname = reader["item_name"].ToString();
                    int amount = (int)reader["item_amount"];
                    float price = (float)reader["price"];
                    storeStock.Add(new Item(itemname, amount, price));
                }
                CloseConnection();
                return storeStock;//filled up or empty if none found

            }
            else
            {
                return storeStock;//empty
            }
        }

        public List<Item> getInventoryItems(int user_id)//Tested
        {
            List<Item> userInventory = new List<Item>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT item.item_name, inventory_item.amount from item, inventory_item " +
                                "LEFT JOIN inventory ON inventory.id = inventory_item.inventory_id " +
                                "LEFT JOIN user ON user.id = inventory.user_id " +
                                "WHERE inventory.user_id = @user_id " +
                                "AND item.id = inventory_item.item_id";
            cmd.Parameters.AddWithValue("@user_id", user_id);
            if (OpenConnection())
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string itemname = reader["item_name"].ToString();
                    int amount = (int)reader["amount"];
                    userInventory.Add(new Item(itemname, amount));
                }
                CloseConnection();
                return userInventory;//filled up or empty if none found

            }
            else
            {
                return userInventory;//empty
            }

        }

        //UserExist statement
        public bool DoesUserExist(string username)//tested
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT username from user WHERE username = @name ";
            cmd.Parameters.AddWithValue("@name", username);
            if (OpenConnection())
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                string user = null;
                while (reader.Read())
                {
                    user = reader["username"].ToString();

                }
                CloseConnection();
                if (user == null)
                {
                    return false;//User doesn't exist
                }
                else
                {
                    return true;//User already exists
                }

            }
            else
            {
                return true;//Omdat er iets moet returnen
            }

        }

        public bool PasswordCorrect(string username, string password)//tested
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT password FROM user WHERE username = @name "; // Voorkomt SQL injectie!!!!
            cmd.Parameters.AddWithValue("@name", username);

            if (OpenConnection())
            {
                string db_password = null;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    db_password = reader["password"].ToString();
                }
                CloseConnection();
                if (db_password.Equals(password))
                {
                    return true;//Password in form is same as password in database
                }
                else
                {
                    return false;//Password in form is NOT the same as password in database
                }


            }
            else
            {
                return false;
            }

        }

        public float UserBalance(string username)//tested
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT balance FROM user WHERE username = @name";
            cmd.Parameters.AddWithValue("@name", username);
            float balance = 0;

            if (OpenConnection())
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    balance = (float)reader["balance"];
                }
                CloseConnection();
                return balance;


            }
            else
            {
                return balance;
            }

        }
    }
}

