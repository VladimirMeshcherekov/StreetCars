using System;
using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Player.Inventory
{
    public class PlayerInventory
    {
        public List<PlayerCarsTypes> OwnedItemsTypes { get; private set; }
        private SaveService<PlayerInventorySaveProperties> _loadInventorySystem;
        private string SaveFilePath { get; } = Application.persistentDataPath + "inventory.cars";

        public PlayerInventory()
        {
            _loadInventorySystem = new SaveService<PlayerInventorySaveProperties>(SaveFilePath);
            OwnedItemsTypes = _loadInventorySystem.LoadFromFile<PlayerInventorySaveProperties>().IsOwnedItemsTypes;

           //ResetInventory(); // debug only

            if (OwnedItemsTypes.Contains(PlayerCarsTypes.Default) == false)
            {
                OwnedItemsTypes.Add(PlayerCarsTypes.Default);
            }
        }

        public void AddNewItemToInventory(PlayerCarsTypes newItemType)
        {
            OwnedItemsTypes.Add(newItemType);
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(OwnedItemsTypes));
        }

        void ResetInventory()
        {
            OwnedItemsTypes = new List<PlayerCarsTypes>();
            _loadInventorySystem.SaveToFile(new PlayerInventorySaveProperties(OwnedItemsTypes));
        }
    }

    [Serializable]
    public struct PlayerInventorySaveProperties
    {
        public List<PlayerCarsTypes> IsOwnedItemsTypes;

        public PlayerInventorySaveProperties(List<PlayerCarsTypes> isOwnedItemsTypes)
        {
            IsOwnedItemsTypes = isOwnedItemsTypes;
        }
    }
}