using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JMCMediaPLayer
{
    class Database
    {
        //Properties
        private string connectionString = "server=127.0.0.1;uid=root;pwd=;database=users";
        private MySqlConnection conn = new MySqlConnection();
        private HashComputer HashComputer = new HashComputer();


        /// <summary>
        /// checks if connection is possible
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open(); 
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Method to add a new user to the database
        public void AddUser(User user)
        {
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();            
                string query = "INSERT INTO `users`(`username`, `password`, `salt`) VALUES (@username,@password,@salt)";
                MySqlCommand statement = new MySqlCommand(query, conn);
                statement.Parameters.AddWithValue("@username", user.UserName);
                statement.Parameters.AddWithValue("@password", user.PasswordHash);
                statement.Parameters.AddWithValue("@salt", user.Salt);
                statement.ExecuteReader();
                conn.Close();
                               
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
        }

        //Method to check if the username and password are correct
        public bool ValidateUser(string userName, string password, out string message)
        {
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                string query = "SELECT `username`, `password`, `salt` FROM `users` WHERE `username`= @username";
                MySqlCommand statement = new MySqlCommand(query, conn);
                
                statement.Parameters.AddWithValue("@username", userName);
                MySqlDataReader sqlDataReader = statement.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    string UsernameValue = sqlDataReader.GetString("username");
                    string passwordValue = sqlDataReader.GetString("password");
                    string saltValue = sqlDataReader.GetString("salt");

                    if (HashComputer.isPasswordMatch(password, saltValue, passwordValue))
                    {
                        conn.Close();
                        message = "Password Matched" + "\n" + "Login as " + userName + "\r\n";
                        return true ;
                    }
                    else
                    {
                        conn.Close();
                        message = "Password did not match!";
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    message = ("The username does not exist in the database!");
                    return false;
                 
                }          
            }
            catch(MySqlException)
            {
                throw ;
            }


        }
    }
}
