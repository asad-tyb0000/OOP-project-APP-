using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.DL.DB
{
    public class CoinsDB : ICoinsDL
    {
        private readonly string connectionString;

        public CoinsDB()
        {
            connectionString = ConnectionDB.GetConnectionString();
        }
        public void CreateCoins(Coins coin)
        {
            string query = "INSERT INTO Coins (Amount, Name, Symbol, Coin_Details) VALUES ( @Amount, @Name, @Symbol, @CoinDetails)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Amount", coin.GetAmount());
                command.Parameters.AddWithValue("@Name", coin.GetName());
                command.Parameters.AddWithValue("@Symbol", coin.GetSymbol());
                command.Parameters.AddWithValue("@CoinDetails", coin.GetDescription());

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

        public Coins GetCoinById(int coinId)
        {
            string query = "SELECT * FROM Coins WHERE ID = @ID";
            Coins coin = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", coinId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        coin = new Coins(
                            reader.GetInt32(0),
                            reader.GetString(2),
                            reader.GetString(4),
                            (float)reader.GetDouble(1),
                            reader.GetString(3)
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return coin;
        }
        public List<Coins> GetAllCoins()
        {
            List<Coins> coins = new List<Coins>();

            string query = "SELECT * FROM Coins";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Coins coin = new Coins(
                            reader.GetInt32(0),
                            reader.GetString(2),
                            reader.GetString(4),
                            (float)reader.GetDouble(1),
                            reader.GetString(3)
                        );
                        coins.Add(coin);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return coins;
        }

        public void UpdateCoins(Coins coin)
        {
            string query = "UPDATE Coins SET Amount = @Amount, Name = @Name, Symbol = @Symbol, Coin_Details = @CoinDetails WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", coin.GetId());
                command.Parameters.AddWithValue("@Amount", coin.GetAmount());
                command.Parameters.AddWithValue("@Name", coin.GetName());
                command.Parameters.AddWithValue("@Symbol", coin.GetSymbol());
                command.Parameters.AddWithValue("@CoinDetails", coin.GetDescription());

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

        public void DeleteCoins(int coinId)
        {
            string query = "DELETE FROM Coins WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", coinId);

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
