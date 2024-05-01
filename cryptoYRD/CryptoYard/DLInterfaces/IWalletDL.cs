using CryptoConsole.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.DLInterfaces
{
    public interface IWalletDL
    {
        void CreateWallet(Wallet wallet);

        Wallet GetWalletById(int userId);

        List<Wallet> GetAllWallets();

        void UpdateWallet(Wallet wallet);

        void DeleteWallet(int userId);
        Wallet GetWalletByUserId(int userId);
    }
}
