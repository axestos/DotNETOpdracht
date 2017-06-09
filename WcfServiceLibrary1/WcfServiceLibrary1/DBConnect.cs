using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WcfServiceLibrary1
{
    class DBConnect
    {

        /*
         TO DO
         BuyService(username, user_money, item) -> Get user_id by name, Check store amount, check balance of user by user_id, check price of product, add to inventory if balance high enough, refresh.
             */
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
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



        public int GetUserID(string username)//Returns ID from certain username
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

                return user_id;//filled up or empty if none found

            }
            else
            {
                return user_id;//empty
            }

        }

        public void InsertNewUser(string username, string password)//Insert new user
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO user(username, password, balance) VALUES(@name,@password,10) "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();//Execute query

                //Makes inventory for user
                MySqlCommand user = connection.CreateCommand();
                user.CommandText = "INSERT INTO inventory(user_id) VALUES(@user_id) ";
                user.Parameters.AddWithValue("@user_id", GetUserID(username));
                user.ExecuteNonQuery();
                CloseConnection();
            }
        }


        public List<Item> getStoreItems()
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

                return storeStock;//filled up or empty if none found

            }
            else
            {
                return storeStock;//empty
            }
        }

        public List<Item> getInventoryItems(int user_id)
        {
            List<Item> userInventory = new List<Item>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT item.item_name, inventory_item.amount from item, inventory_item " +
                                "LEFT JOIN inventory ON inventory.id = inventory_item.inventory_id " +
                                "LEFT JOIN user ON user.id = inventory.user_id"+
                                "WHERE inventory.user_id = @user_id";
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

                return userInventory;//filled up or empty if none found

            }
            else
            {
                return userInventory;//empty
            }

        }

        //UserExist statement
        public bool DoesUserExist(string username)
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

        public bool PasswordCorrect(string username, string password)
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

        public float UserBalance(string username)
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

                return balance;


            }
            else
            {
                return balance;
            }

        }

    }
}
