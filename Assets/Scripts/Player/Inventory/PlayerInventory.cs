using System;
using System.Collections.Generic;

namespace Player
{
    public class PlayerInventory
    {
        public List<int> _isOwnedItemsID;
        private LoadInventory _loadInventory;
        
        public PlayerInventory()
        {
            _loadInventory = new LoadInventory();
            _isOwnedItemsID = _loadInventory.LoadFromFile().IsOwnedItemsID;
            if (_isOwnedItemsID.Contains(0)== false)
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