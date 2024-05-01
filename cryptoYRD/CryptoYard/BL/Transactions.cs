using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.BL
{
    public class Transactions
    {
        private int Id;
        private int SenderId;
        private int CoinId;
        private int ReceiverId;
        private float Amount;
        private DateTime Date;

        // Constructor
        public Transactions(int id, int senderId, int coinId, int receiverId, float amount, DateTime date)
        {
            Id = id;
            SenderId = senderId;
            CoinId = coinId;
            ReceiverId = receiverId;
            Amount = amount;
            Date = date;
        }

        // Getters and Setters
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public int GetSenderId()
        {
            return SenderId;
        }

        public void SetSenderId(int senderId)
        {
            SenderId = senderId;
        }

        public int GetCoinId()
        {
            return CoinId;
        }

        public void SetCoinId(int coinId)
        {
            CoinId = coinId;
        }

        public int GetReceiverId()
        {
            return ReceiverId;
        }

        public void SetReceiverId(int receiverId)
        {
            ReceiverId = receiverId;
        }

        public float GetAmount()
        {
            return Amount;
        }

        public void SetAmount(float amount)
        {
            Amount = amount;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public void SetDate(DateTime date)
        {
            Date = date;
        }

        // Function to return all properties as an object
        public object GetAllPropertiesObject()
        {
            return new
            {
                Id = Id,
                SenderId = SenderId,
                CoinId = CoinId,
                ReceiverId = ReceiverId,
                Amount = Amount,
                Date = Date
            };
        }

        // Function to update all properties from another Transactions object
        public void UpdateAllProperties(Transactions updatedTransaction)
        {
            Id = updatedTransaction.Id;
            SenderId = updatedTransaction.SenderId;
            CoinId = updatedTransaction.CoinId;
            ReceiverId = updatedTransaction.ReceiverId;
            Amount = updatedTransaction.Amount;
            Date = updatedTransaction.Date;
        }
    }
}
