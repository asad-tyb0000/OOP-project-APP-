using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CryptoConsole.DL.FH
{
    public class TransactionsFH : ITransactionDL
    {
        private static readonly string filePath = ConnectionFH.GetTransactionsFilePath();

        public void CreateTransaction(Transactions transaction)
        {
            try
            {
                int transactionId;
                if (File.Exists(filePath))
                {
                    transactionId = GetAllTransactions().Max(t => t.GetId()) + 1;
                }
                else
                {
                    transactionId = 1;
                }

                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{transactionId},{transaction.GetSenderId()},{transaction.GetCoinId()},{transaction.GetReceiverId()},{transaction.GetAmount()},{transaction.GetDate()}");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Transactions GetTransactionById(int transactionId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] transactionDetails = line.Split(',');
                    if (int.TryParse(transactionDetails[0], out int id) && id == transactionId)
                    {
                        return ParseTransactionDetails(transactionDetails);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<Transactions> GetAllTransactions()
        {
            List<Transactions> transactions = new List<Transactions>();
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] transactionDetails = line.Split(',');
                        Transactions transaction = ParseTransactionDetails(transactionDetails);
                        if (transaction != null)
                        {
                            transactions.Add(transaction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

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

        private Transactions ParseTransactionDetails(string[] transactionDetails)
        {
            if (transactionDetails.Length >= 6)
            {
                int id = int.Parse(transactionDetails[0]);
                int senderId = int.Parse(transactionDetails[1]);
                int coinId = int.Parse(transactionDetails[2]);
                int receiverId = int.Parse(transactionDetails[3]);
                float amount = float.Parse(transactionDetails[4]);
                DateTime date = DateTime.Parse(transactionDetails[5]);
                return new Transactions(id, senderId, coinId, receiverId, amount, date);
            }
            return null;
        }
    }
}
