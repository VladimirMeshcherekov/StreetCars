using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerInventory
    {
        public List<int> _isOwnedItemsID { get; private set; }
        private SaveService<PlayerInventorySaveProperties> _loadInventorySystem;
        private string SaveFilePath { get; } = Application.persistentDataPath + "inventory.cars";

        public PlayerInventory()
        {
            _loadInventorySystem = new SaveService<PlayerInventorySaveProperties>(SaveFilePath);
            _isOwnedItemsID = _loadInventorySystem.LoadFromFile<PlayerInventorySaveProperties>().IsOwnedItemsID;

            ResetInventory(); // debug only
            
            if (_isOwnedItemsID.Contains(0) == false)
            {
                _isOwnedItemsID.Add(0);
            }
        }

        public void AddNewItemToInventory(int newItemID)
        {
            _isOwnedItemsID.Add(newItemID);
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(_isOwnedItemsID));
        }

        void ResetInventory()
        {
            _isOwnedItemsID = new List<int>(); 
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(_isOwnedItemsID));
        }
    }

    [Serializable]
    public struct PlayerInventorySaveProperties
    {
        public List<int> IsOwnedItemsID;

        public PlayerInventorySaveProperties(List<int> isOwnedItemsID)
        {
            IsOwnedItemsID = isOwnedItemsID;
        }
    }
}