using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerInventory
    {
        public List<int> _isOwnedItemsID;
        private SaveService<PlayerInventorySaveProperties> _loadInventorySystem;
        private string SaveFilePath { get; } = Application.persistentDataPath + "inventory.cars";

        public PlayerInventory()
        {
            _loadInventorySystem = new SaveService<PlayerInventorySaveProperties>(SaveFilePath);
            _isOwnedItemsID = _loadInventorySystem.LoadFromFile<PlayerInventorySaveProperties>().IsOwnedItemsID;

            if (_isOwnedItemsID.Contains(0) == false)
            {
                _isOwnedItemsID.Add(0);
            }
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