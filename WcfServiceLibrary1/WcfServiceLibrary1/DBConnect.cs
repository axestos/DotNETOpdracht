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
            database = "webshop";
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

        public void InsertNewUser(string username, string password)//Insert,update,delete
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO user(username, password, balance) VALUES(@name,@password,10) "; // Voorkomt SQL injectie!!!!
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();//Execute query
                this.CloseConnection();
            }
        }

        //UserExist statement
        public bool DoesUserExist(string username) {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT name from user WHERE username = @name "; // Voorkomt SQL injectie!!!!
            cmd.Parameters.AddWithValue("@name", username);
            if (OpenConnection())
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                string user = null;
                while (reader.Read())
                {
                    user = reader["name"].ToString();
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
                return true;
            }

        }

    }
}
