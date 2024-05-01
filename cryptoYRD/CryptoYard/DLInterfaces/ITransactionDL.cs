using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoConsole.BL;

namespace CryptoConsole.DLInterfaces
{
    public interface ITransactionDL
    {
        // Create a new transaction
        void CreateTransaction(Transactions transaction);

        // Retrieve a transaction by its ID
        Transactions GetTransactionById(int transactionId);

        // Retrieve all transactions
        List<Transactions> GetAllTransactions();

        // Update an existing transaction
        void UpdateTransaction(Transactions transaction);

        // Delete a transaction by its ID
        void DeleteTransaction(int transactionId);
    }
}
