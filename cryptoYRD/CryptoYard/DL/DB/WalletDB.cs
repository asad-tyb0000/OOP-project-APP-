using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace CryptoConsole.DL.DB
{
    public class WalletDB : IWalletDL
    {
        private readonly string connectionString;

        public WalletDB()
        {
            this.connectionString = ConnectionDB.GetConnectionString();
        }

        public void CreateWallet(Wallet wallet)
        {
            string query = "INSERT INTO Wallet (UserID, WalletNumber) VALUES (@UserID, @WalletNumber);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", wallet.GetUserID());
                command.Parameters.AddWithValue("@WalletNumber", wallet.GetWalletNumber());

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public Wallet GetWalletByUserId(int userId)
        {
            string query = "SELECT * FROM Wallet WHERE UserID = @UserID";
            Wallet wallet = null;

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
                        wallet = new Wallet(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2)
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return wallet;
        }
        public Wallet GetWalletById(int walletId)
        {
            string query = "SELECT * FROM Wallet WHERE Id = @ID";
            Wallet wallet = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", walletId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        wallet = new Wallet(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2)
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return wallet;
        }

        public List<Wallet> GetAllWallets()
        {
            List<Wallet> wallets = new List<Wallet>();

            string query = "SELECT * FROM Wallet";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Wallet wallet = new Wallet(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2)
                        );
                        wallets.Add(wallet);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return wallets;
        }

        public void UpdateWallet(Wallet wallet)
        {
            string query = "UPDATE Wallet SET UserID = @UserID, WalletNumber = @WalletNumber WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", wallet.GetID());
                command.Parameters.AddWithValue("@UserID", wallet.GetUserID());
                command.Parameters.AddWithValue("@WalletNumber", wallet.GetWalletNumber());

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
            }
        }

        public void DeleteWallet(int walletId)
        {
            string query = "DELETE FROM Wallet WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", walletId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
