using System.IO;
using UnityEngine;

namespace Player
{
    public class WalletSaveSystem
    {
        private PlayerWalletSaveProperties _wallet;
        
        public PlayerWalletSaveProperties LoadFromFile()
        {
            if (!File.Exists(SaveFilePath()))
            {
                SaveToFile(_wallet);
            }

            var json = File.ReadAllText(SaveFilePath());
            return JsonUtility.FromJson<PlayerWalletSaveProperties>(json);
        }
        
        public void SaveToFile(PlayerWalletSaveProperties wallet)
        {
            var json = JsonUtility.ToJson(wallet);
            File.WriteAllText(SaveFilePath(), json);
        }
        
        private string SaveFilePath()
        {
            return Application.persistentDataPath + "wallet.cars";
        }
    }
}