using CryptoConsole.BL;
using CryptoConsole.DLInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CryptoConsole.DL.FH
{
    public class AssetsFH : IAssetsDL
    {
        private static readonly string filePath = ConnectionFH.GetAssetsFilePath();

        public void CreateAsset(Assets asset)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{asset.GetId()},{asset.GetCoinId()},{asset.GetAmount()},{asset.GetStatus()},{asset.GetWalletId()}");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Assets GetAssetById(int assetId)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] assetDetails = line.Split(',');
                    if (int.TryParse(assetDetails[0], out int id) && id == assetId)
                    {
                        return ParseAssetDetails(assetDetails);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<Assets> GetAssetsByWalletId(int walletId)
        {
            List<Assets> assets = new List<Assets>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] assetDetails = line.Split(',');
                    if (int.TryParse(assetDetails[4], out int id) && id == walletId)
                    {
                        Assets asset = ParseAssetDetails(assetDetails);
                        if (asset != null)
                        {
                            assets.Add(asset);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return assets;
        }

        public void UpdateAsset(Assets asset)
        {
            List<Assets> assets = GetAllAssets();
            int index = assets.FindIndex(a => a.GetId() == asset.GetId());
            if (index != -1)
            {
                assets[index] = asset;
                UpdateAssetsFile(assets);
            }
            else
            {

            }
        }

        public void DeleteAsset(int assetId)
        {
            List<Assets> assets = GetAllAssets();
            assets.RemoveAll(a => a.GetId() == assetId);
            UpdateAssetsFile(assets);
        }

        public List<Assets> GetAllAssets()
        {
            List<Assets> assets = new List<Assets>();
            try
            {
                if (!File.Exists(filePath))
                {
                    return assets;
                }

                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] assetDetails = line.Split(',');
                    Assets asset = ParseAssetDetails(assetDetails);
                    if (asset != null)
                    {
                        assets.Add(asset);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return assets;
        }

        private void UpdateAssetsFile(List<Assets> assets)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Assets asset in assets)
                    {
                        writer.WriteLine($"{asset.GetId()},{asset.GetCoinId()},{asset.GetAmount()},{asset.GetStatus()},{asset.GetWalletId()}");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Assets ParseAssetDetails(string[] assetDetails)
        {
            if (assetDetails.Length >= 5)
            {
                int id = int.Parse(assetDetails[0]);
                int coinId = int.Parse(assetDetails[1]);
                float amount = float.Parse(assetDetails[2]);
                string status = assetDetails[3];
                int walletId = int.Parse(assetDetails[4]);
                return new Assets(id, coinId, amount, status, walletId);
            }
            return null;
        }
    }
}
