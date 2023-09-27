using Player;
using Player.Inventory;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class BuyItemButton : MonoBehaviour
    {
        private PlayerCarsTypes _itemType;
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

        public void SetItemID(PlayerCarsTypes itemType, int price)
        {
            _itemType = itemType;
            _price = price;
        }
        public void TryBuyItem()
        {
            if (_playerWallet.TryToSpendCoins(_price))
            {
                _playerInventory.AddNewItemToInventory(_itemType);
                _eventBus.Invoke(new AddNewItemToInventorySignal(_itemType));
                _eventBus.Invoke(new PlayerWalletValueChangedSignal());
            }
        }
    }
}
