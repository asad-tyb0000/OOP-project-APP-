using CryptoConsole.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoConsole.BL;

namespace CryptoConsole.DLInterfaces
{
    public interface ICoinsDL
    {
        void CreateCoins(Coins coin);

        Coins GetCoinById(int coinId);

        List<Coins> GetAllCoins();

        void UpdateCoins(Coins coin);

        void DeleteCoins(int coinId);
    }
}
