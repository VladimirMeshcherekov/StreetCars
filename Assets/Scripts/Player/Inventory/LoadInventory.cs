using System.IO;
using UnityEngine;

namespace Player
{
    public class LoadInventory
    {
        private PlayerInventorySaveProperties _inventory;
        public PlayerInventorySaveProperties LoadFromFile()
        {
            if (!File.Exists(SaveFilePath()))
            {
                SaveToFile(_inventory);
            }

            var json = File.ReadAllText(SaveFilePath());
            return JsonUtility.FromJson<PlayerInventorySaveProperties>(json);
        }
        
        public void SaveToFile(PlayerInventorySaveProperties inventory)
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