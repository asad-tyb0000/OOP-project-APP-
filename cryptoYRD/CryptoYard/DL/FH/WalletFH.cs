using CryptoConsole.BL;
using CryptoConsole.DL.DB;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.DL.FH
{
    public class WalletFH : IWalletDL
    {
        private static readonly string filePath = ConnectionFH.GetWalletFilePath();

        public void CreateWallet(Wallet wallet)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{wallet.GetID()},{wallet.GetUserID()},{wallet.GetWalletNumber()}");
                }
            }
            catch (Exception ex)
            {
            }
        }
        public Wallet GetWalletByUserId(int userId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] walletDetails = line.Split(',');
                    if (int.TryParse(walletDetails[1], out int id) && id == userId)
                    {
                        return ParseWalletDetails(walletDetails);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public Wallet GetWalletById(int userId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] walletDetails = line.Split(',');
                    if (int.TryParse(walletDetails[0], out int id) && id == userId)
                    {
                        return ParseWalletDetails(walletDetails);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<Wallet> GetAllWallets()
        {
            List<Wallet> wallets = new List<Wallet>();
            try
            {
                if (!File.Exists(filePath))
                {
                    return wallets;
                }

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] walletDetails = line.Split(',');
                    Wallet wallet = ParseWalletDetails(walletDetails);
                    if (wallet != null)
                    {
                        wallets.Add(wallet);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return wallets;
        }

        public void UpdateWallet(Wallet wallet)
        {
            List<Wallet> wallets = GetAllWallets();
            int index = wallets.FindIndex(w => w.GetUserID() == wallet.GetUserID());
            if (index != -1)
            {
                wallets[index] = wallet;
                UpdateWalletsFile(wallets);
            }
            else
            {
            }
        }

        public void DeleteWallet(int userId)
        {
            List<Wallet> wallets = GetAllWallets();
            wallets.RemoveAll(w => w.GetUserID() == userId);
            UpdateWalletsFile(wallets);
        }

        private void UpdateWalletsFile(List<Wallet> wallets)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Wallet wallet in wallets)
                    {
                        writer.WriteLine($"{wallet.GetID()},{wallet.GetUserID()},{wallet.GetWalletNumber()}");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private Wallet ParseWalletDetails(string[] walletDetails)
        {
            if (walletDetails.Length >= 2)
            {
                int id = int.Parse(walletDetails[0]);
                int userId = int.Parse(walletDetails[1]);
                string walletNumber = (walletDetails[2]);
                return new Wallet(id, userId, walletNumber);
            }
            return null;
        }
    }
}
