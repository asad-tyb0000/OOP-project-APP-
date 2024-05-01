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
    public class AssetsDB : IAssetsDL
    {
        private readonly string connectionString;

        public AssetsDB()
        {
            this.connectionString = ConnectionDB.GetConnectionString();
        }

        public void CreateAsset(Assets asset)
        {
            string query = "INSERT INTO Assets (CoinID, Amount, Assests_Status, WalletId) VALUES (@CoinID, @Amount, @Assests_Status, @WalletId);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CoinID", asset.GetCoinId());
                command.Parameters.AddWithValue("@Amount", asset.GetAmount());
                command.Parameters.AddWithValue("@Assests_Status", asset.GetStatus());
                command.Parameters.AddWithValue("@WalletId", asset.GetWalletId());

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Assets GetAssetById(int assetId)
        {
            string query = "SELECT * FROM Assets WHERE Id = @ID";
            Assets asset = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", assetId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        asset = new Assets(
                            reader.GetInt32(0),
                            reader.GetInt32(2),
                            (float)reader.GetDouble(3),
                            reader.GetString(4),
                            reader.GetInt32(5)
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return asset;
        }

        public List<Assets> GetAssetsByWalletId(int walletId)
        {
            List<Assets> assets = new List<Assets>();

            string query = "SELECT * FROM Assets WHERE WalletId = @WalletIds";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@WalletIds", walletId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Assets asset = new Assets(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            (float)reader.GetDouble(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        );
                        assets.Add(asset);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return assets;
        }

        public void UpdateAsset(Assets asset)
        {
            string query = "UPDATE Assets SET CoinID = @CoinID, Amount = @Amount, Assests_Status = @Assests_Status WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", asset.GetId());
                command.Parameters.AddWithValue("@CoinID", asset.GetCoinId());
                command.Parameters.AddWithValue("@Amount", asset.GetAmount());
                command.Parameters.AddWithValue("@Assests_Status", asset.GetStatus());

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

        public void DeleteAsset(int assetId)
        {
            string query = "DELETE FROM Assets WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", assetId);

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
        public List<Assets> GetAllAssets()
        {
            List<Assets> assets = new List<Assets>();

            string query = "SELECT * FROM Assets";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Assets asset = new Assets(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            (float)reader.GetDouble(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        );
                        assets.Add(asset);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return assets;
        }

    }
}
