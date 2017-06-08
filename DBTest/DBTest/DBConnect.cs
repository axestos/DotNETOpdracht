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
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
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
                CloseConnection();
            }
        }

        //UserExist statement
        public bool DoesUserExist(string username)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT username from user WHERE username = @name "; // Voorkomt SQL injectie!!!!
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
                return true;
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
    }
}
