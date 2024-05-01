using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoConsole.DL;
using CryptoConsole.DL.FH;
using CryptoConsole.DL.DB;

namespace CryptoConsole.BL
{
    public class Customers : User
    {
        // Wallet properties
        private Wallet wallet;

        // Constructor
        public Customers(int userId, string userName, string password, string role, long cnic, DateTime dateCreated,
                         int walletId, int coinId, float walletAmount, string walletNumber)
                         : base(userId, userName, password, role, cnic, dateCreated)
        {
            wallet = new Wallet(walletId, userId, walletNumber);
        }
        public Wallet GetWallet()
        {
            return wallet;
        }

        // Method to transfer funds from the wallet
        public void TransferFunds(int recipientUserId, float amount)
        {
            // You may want to add validation or business logic here
            // Assuming you have a method in Wallet to transfer funds
            //wallet.TransferFunds(recipientUserId, amount);
        }

        // Method to view transaction history of the wallet
        public List<Transactions> ViewTransactionHistory()
        {
            // You may want to add validation or business logic here
            return wallet.GetAllTransactions();
        }

    }
}
