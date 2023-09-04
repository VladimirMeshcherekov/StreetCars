using System.IO;
using UnityEngine;

namespace Player
{
    public class LoadInventory
    {
        private PlayerInventory _inventory;

        public LoadInventory(PlayerInventory inventory)
        {
            _inventory = inventory;
            LoadFromFile();
        }
        
        private void LoadFromFile()
        {
            if (!File.Exists(SaveFilePath()))
            {
                SaveToFile(_inventory);
            }

            var json = File.ReadAllText(SaveFilePath());
            JsonUtility.FromJsonOverwrite(json, _inventory);
        }
        
        private void SaveToFile(PlayerInventory inventory)
        {
            var json = JsonUtility.ToJson(inventory);
            File.WriteAllText(SaveFilePath(), json);
        }
        
        
        private string SaveFilePath()
        {
            return Application.persistentDataPath + "inventory.cars";
        }
    }
}