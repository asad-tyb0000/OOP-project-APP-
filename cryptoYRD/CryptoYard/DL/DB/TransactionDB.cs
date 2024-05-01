using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace CryptoConsole.DL.DB
{
    public class TransactionsDB : ITransactionDL
    {
        private readonly string connectionString;

        public TransactionsDB()
        {
            this.connectionString = ConnectionDB.GetConnectionString();
        }

        public void CreateTransaction(Transactions transaction)
        {
            string query = "INSERT INTO Transactions (SenderId, CoinId, ReceiverId, Amount, Date) VALUES (@SenderId, @CoinId, @ReceiverId, @Amount, @Date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SenderId", transaction.GetSenderId());
                command.Parameters.AddWithValue("@CoinId", transaction.GetCoinId());
                command.Parameters.AddWithValue("@ReceiverId", transaction.GetReceiverId());
                command.Parameters.AddWithValue("@Amount", transaction.GetAmount());
                command.Parameters.AddWithValue("@Date", transaction.GetDate());

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

        public Transactions GetTransactionById(int transactionId)
        {
            string query = "SELECT * FROM Transactions WHERE Id = @ID";
            Transactions transaction = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", transactionId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        transaction = new Transactions(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            (float)reader.GetDouble(4),
                            reader.GetDateTime(5)
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return transaction;
        }

        public List<Transactions> GetAllTransactions()
        {
            List<Transactions> transactions = new List<Transactions>();

            string query = "SELECT * FROM Transactions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Transactions transaction = new Transactions(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            (float)reader.GetDouble(4),
                            reader.GetDateTime(5)
                        );
                        transactions.Add(transaction);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return transactions;
        }

        public void UpdateTransaction(Transactions transaction)
        {
            // Implement update logic
        }

        public void DeleteTransaction(int transactionId)
        {
            // Implement delete logic
        }
    }
}
