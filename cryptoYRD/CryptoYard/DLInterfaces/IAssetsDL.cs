using CryptoConsole.BL;
using CryptoConsole.DL.DB;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CryptoConsole.DLInterfaces
{
    public interface IAssetsDL
    {
        // Create a new asset
        void CreateAsset(Assets asset);

        // Retrieve an asset by its ID
        Assets GetAssetById(int assetId);

        // Retrieve all assets associated with a wallet
        List<Assets> GetAssetsByWalletId(int walletId);

        // Update an existing asset
        void UpdateAsset(Assets asset);

        // Delete an asset by its ID
        void DeleteAsset(int assetId);
        List<Assets> GetAllAssets();
    }
}
