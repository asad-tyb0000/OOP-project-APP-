using System;
using System.Collections.Generic;
using System.IO;
using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System.Linq;


namespace CryptoConsole.DL.FH
{
    public class CoinsFH : ICoinsDL
    {
        private static readonly string filePath = ConnectionFH.GetCoinsFilePath();

        public void CreateCoins(Coins coin)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{coin.GetId()},{coin.GetName()},{coin.GetDescription()},{coin.GetAmount()},{coin.GetSymbol()}");
                }

            }
            catch (Exception ex)
            {

            }
        }

        public Coins GetCoinById(int coinId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] coinDetails = line.Split(',');
                    if (int.TryParse(coinDetails[0], out int id) && id == coinId)
                    {
                        return ParseCoinDetails(coinDetails);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<Coins> GetAllCoins()
        {
            List<Coins> coins = new List<Coins>();
            try
            {
                if (!File.Exists(filePath))
                {

                    return coins;
                }

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] coinDetails = line.Split(',');
                    Coins coin = ParseCoinDetails(coinDetails);
                    if (coin != null)
                    {
                        coins.Add(coin);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return coins;
        }

        public void UpdateCoins(Coins coin)
        {
            List<Coins> coins = GetAllCoins();
            int index = coins.FindIndex(c => c.GetId() == coin.GetId());
            if (index != -1)
            {
                coins[index] = coin;
                UpdateCoinsFile(coins);

            }
            else
            {

            }
        }

        public void DeleteCoins(int coinId)
        {
            List<Coins> coins = GetAllCoins();
            coins.RemoveAll(c => c.GetId() == coinId);
            UpdateCoinsFile(coins);

        }

        private void UpdateCoinsFile(List<Coins> coins)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Coins coin in coins)
                    {
                        writer.WriteLine($"{coin.GetId()},{coin.GetName()},{coin.GetDescription()},{coin.GetAmount()},{coin.GetSymbol()}");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Coins ParseCoinDetails(string[] coinDetails)
        {
            if (coinDetails.Length >= 5)
            {
                int id = int.Parse(coinDetails[0]);
                string name = coinDetails[1];
                string description = coinDetails[2];
                float amount = float.Parse(coinDetails[3]);
                string symbol = coinDetails[4];
                return new Coins(id, name, description, amount, symbol);
            }
            return null;
        }
    }
}
