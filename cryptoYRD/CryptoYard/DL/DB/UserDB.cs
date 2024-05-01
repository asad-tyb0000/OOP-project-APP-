using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;

namespace CryptoConsole.DL.DB
{
    public class UserDB : IUserDL
    {
        private readonly string connectionString;

        public UserDB()
        {
            this.connectionString = ConnectionDB.GetConnectionString();
        }

        public void CreateUser(User user)
        {
            string query = "INSERT INTO Users (UserID, UserName, UserPassword, UserRole, UserCNIC, DateCreated) " +
                           "VALUES (@UserID, @UserName, @UserPassword, @UserRole, @UserCNIC, @DateCreated)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.GetUserId());
                command.Parameters.AddWithValue("@UserName", user.GetUserName());
                command.Parameters.AddWithValue("@UserPassword", user.GetPassword());
                command.Parameters.AddWithValue("@UserRole", user.GetRole());
                command.Parameters.AddWithValue("@UserCNIC", user.GetCnic());
                command.Parameters.AddWithValue("@DateCreated", user.GetDateCreated());

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public User GetUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            User user = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User(
                            Convert.ToInt32(reader["UserID"]),
                            Convert.ToString(reader["UserName"]),
                            Convert.ToString(reader["UserPassword"]),
                            Convert.ToString(reader["UserRole"]),
                            Convert.ToInt64(reader["UserCNIC"]),
                            Convert.ToDateTime(reader["DateCreated"])
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }
            return user;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(
                            Convert.ToInt32(reader["UserID"]),
                            Convert.ToString(reader["UserName"]),
                            Convert.ToString(reader["UserPassword"]),
                            Convert.ToString(reader["UserRole"]),
                            Convert.ToInt64(reader["UserCNIC"]),
                            Convert.ToDateTime(reader["DateCreated"])
                        );
                        users.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE Users SET UserName = @UserName, UserPassword = @UserPassword, " +
                           "UserRole = @UserRole, UserCNIC = @UserCNIC, DateCreated = @DateCreated " +
                           "WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", user.GetUserId());
                command.Parameters.AddWithValue("@UserName", user.GetUserName());
                command.Parameters.AddWithValue("@UserPassword", user.GetPassword());
                command.Parameters.AddWithValue("@UserRole", user.GetRole());
                command.Parameters.AddWithValue("@UserCNIC", user.GetCnic());
                command.Parameters.AddWithValue("@DateCreated", user.GetDateCreated());

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }


    }
}
