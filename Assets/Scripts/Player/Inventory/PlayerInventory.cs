using System;
using System.Collections.Generic;

namespace Player
{
    [Serializable]
    public class PlayerInventory
    {
        public List<int> _isOwnedItemsID;
        private LoadInventory _loadInventory;
        
        public PlayerInventory()
        {
            _loadInventory = new LoadInventory(this);
            if (_isOwnedItemsID.Contains(0)== false)
            {
                _isOwnedItemsID.Add(0);
            }
        }
        
    }
}