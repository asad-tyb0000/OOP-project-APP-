using System;
using System.Collections.Generic;

namespace CryptoConsole.BL
{
    public class Wallet
    {
        private int ID;
        private int UserID;
        private string WalletNumber;
        private List<Assets> Assets;
        private List<Transactions> Transactions;

        // Constructor
        public Wallet(int id, int userId, string walletNumber)
        {
            ID = id;
            UserID = userId;
            WalletNumber = walletNumber;
            Assets = new List<Assets>();
            Transactions = new List<Transactions>();
        }

        // Getter and setter for ID property
        public int GetID()
        {
            return ID;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        // Getter and setter for UserID property
        public int GetUserID()
        {
            return UserID;
        }

        public void SetUserID(int userId)
        {
            UserID = userId;
        }

        // Getter and setter for CoinID property

        // Getter and setter for WalletNumber property
        public string GetWalletNumber()
        {
            return WalletNumber;
        }

        public void SetWalletNumber(string walletNumber)
        {
            WalletNumber = walletNumber;
        }

        // Getter and setter for Assets property
        public List<Assets> GetAssets()
        {
            return Assets;
        }

        public void SetAssets(List<Assets> assets)
        {
            Assets = assets;
        }

        // Getter and setter for Transactions property
        public List<Transactions> GetTransactions()
        {
            return Transactions;
        }

        public void SetTransactions(List<Transactions> transactions)
        {
            Transactions = transactions;
        }

        // Function to return all properties as an object
        public object GetAllPropertiesObject()
        {
            return new
            {
                ID = this.ID,
                UserID = this.UserID,
                WalletNumber = this.WalletNumber
            };
        }

        // Method to update all properties from another Wallet object
        public void UpdateAllProperties(Wallet updatedWallet)
        {
            ID = updatedWallet.ID;
            UserID = updatedWallet.UserID;
            WalletNumber = updatedWallet.WalletNumber;
        }

        // Method to add an asset to the wallet
        public void AddAsset(Assets asset)
        {
            Assets.Add(asset);
        }

        // Method to remove an asset from the wallet
        public void RemoveAsset(Assets asset)
        {
            Assets.Remove(asset);
        }

        // Method to get all assets in the wallet
        public List<Assets> GetAllAssets()
        {
            return Assets;
        }

        // Method to add a transaction to the wallet
        public void AddTransaction(Transactions transaction)
        {
            Transactions.Add(transaction);
        }

        // Method to remove a transaction from the wallet
        public void RemoveTransaction(Transactions transaction)
        {
            Transactions.Remove(transaction);
        }

        // Method to get all transactions in the wallet
        public List<Transactions> GetAllTransactions()
        {
            return Transactions;
        }

        //public void TransferFunds(int recipientUserId, float amount)
        //{
        //    // Check if sender has sufficient funds
        //    if (Amount >= amount)
        //    {
        //        // Deduct amount from sender's wallet
        //        DeductAmount(amount);

        //        // Retrieve recipient's wallet using recipientUserId (Assuming you have a method to get recipient's wallet)
        //        Wallet recipientWallet = GetRecipientWallet(recipientUserId);

        //        // Add amount to recipient's wallet
        //        recipientWallet.AddAmount(amount);

        //        // Create a transaction object to record the transfer
        //        Transactions transaction = new Transactions(
        //            SenderId: this.UserID,
        //            ReceiverId: recipientUserId,
        //            CoinId: this.CoinID,
        //            Amount: amount,
        //            Date: DateTime.Now
        //        );

        //        // Add transaction to sender's wallet
        //        AddTransaction(transaction);

        //        // Add transaction to recipient's wallet (optional)
        //        recipientWallet.AddTransaction(transaction);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Insufficient funds in the wallet.");
        //    }
        //}

        // Method to calculate total value of assets in the wallet
        public float CalculateTotalAssetValue()
        {
            float totalValue = 0;
            foreach (var asset in Assets)
            {
                totalValue += asset.GetAmount();
            }
            return totalValue;
        }


    }
}
