using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.BL
{
    public class Coins
    {
        private int Id;
        private string Name;
        private string Description;
        private double Amount;
        private string Symbol;
        public Coins(int id, string name, string description, double amount, string symbol)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
            Symbol = symbol;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public double GetAmount()
        {
            return Amount;
        }

        public void SetAmount(double amount)
        {
            Amount = amount;
        }

        public string GetSymbol()
        {
            return Symbol;
        }

        public void SetSymbol(string symbol)
        {
            Symbol = symbol;
        }

        public object GetAllPropertiesObject()
        {
            return new
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Amount = this.Amount,
                Symbol = this.Symbol
            };
        }
        public void UpdateAllProperties(Coins updatedCoins)
        {
            Id = updatedCoins.Id;
            Name = updatedCoins.Name;
            Description = updatedCoins.Description;
            Amount = updatedCoins.Amount;
            Symbol = updatedCoins.Symbol;
        }
    }
}
