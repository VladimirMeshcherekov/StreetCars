using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerInventory
    {
        public List<int> IsOwnedItemsID { get; private set; }
        private SaveService<PlayerInventorySaveProperties> _loadInventorySystem;
        private string SaveFilePath { get; } = Application.persistentDataPath + "inventory.cars";

        public PlayerInventory()
        {
            _loadInventorySystem = new SaveService<PlayerInventorySaveProperties>(SaveFilePath);
            IsOwnedItemsID = _loadInventorySystem.LoadFromFile<PlayerInventorySaveProperties>().IsOwnedItemsID;

           // ResetInventory(); // debug only

            if (IsOwnedItemsID.Contains(0) == false)
            {
                IsOwnedItemsID.Add(0);
            }
        }

        public void AddNewItemToInventory(int newItemID)
        {
            IsOwnedItemsID.Add(newItemID);
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(IsOwnedItemsID));
        }

        void ResetInventory()
        {
            IsOwnedItemsID = new List<int>();
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(IsOwnedItemsID));
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