using Player;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class BuyItemButton : MonoBehaviour
    {
        private int _itemID;
        private int _price;

        private PlayerWallet _playerWallet;
        private PlayerInventory _playerInventory;
        private EventBus _eventBus;
        
        [Inject]
        void Construct(PlayerWallet playerWallet, PlayerInventory playerInventory, EventBus eventBus)
        {
            _playerWallet = playerWallet;
            _playerInventory = playerInventory;
            _eventBus = eventBus;
        }

        public void SetItemID(int itemID, int price)
        {
            _itemID = itemID;
            _price = price;
        }
        public void TryBuyItem()
        {
            if (_playerWallet.TryToSpendCoins(_price))
            {
                _playerInventory.AddNewItemToInventory(_itemID);
                _eventBus.Invoke(new AddNewItemToInventorySignal(_itemID));
                _eventBus.Invoke(new PlayerWalletValueChangedSignal());
            }
        }
    }
}
