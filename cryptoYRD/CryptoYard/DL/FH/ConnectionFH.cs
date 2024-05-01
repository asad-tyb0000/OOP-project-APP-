using System;
using System.IO;

namespace CryptoConsole.DL.FH
{
    public class ConnectionFH
    {
        public static string GetUsersFilePath()
        {
            string filePath = "users.txt";
            CheckFileExistence(filePath);

            return filePath;
        }

        public static string GetCoinsFilePath()
        {
            string filePath = "coins.txt";
            CheckFileExistence(filePath);
            return filePath;
        }

        public static string GetTransactionsFilePath()
        {
            string filePath = "transactions.txt";
            return filePath;
        }

        public static string GetAssetsFilePath()
        {
            string filePath = "assets.txt";
            CheckFileExistence(filePath);
            return filePath;
        }

        public static string GetWalletFilePath()
        {
            string filePath = "wallet.txt";
            CheckFileExistence(filePath);
            return filePath;
        }

        private static void CheckFileExistence(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();

                if (filePath == "coins.txt")
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("0, USD Tether, Similar to USD, 280, USDT");
                    }
                }
            }

        }
    }
}
