using System.Collections.Generic;
using Player;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class PlayerShop : MonoBehaviour
    {
        [SerializeField] private ShopItemList carPropertiesList;
        [SerializeField] private ShopItem shopItem;
        [SerializeField] private Transform shopContentList;

        private Dictionary<int, ShopItem> _itemsByID = new Dictionary<int, ShopItem>();
        private PlayerInventory _inventory;
        private EventBus _eventBus;

        [Inject]
        private void Construct(PlayerInventory inventory, EventBus eventBus)
        {
            _inventory = inventory;
            _eventBus = eventBus;
        }

        private void Start()
        {
            _eventBus.Subscribe<AddNewItemToInventorySignal>(ReloadItem, 0);
            LoadItemList();
        }

        private void LoadItemList()
        {
            foreach (var carProperties in carPropertiesList.carPropertiesList)
            {
                var newItem = Instantiate(shopItem, shopContentList);
                newItem.SetItem(carProperties, _inventory._isOwnedItemsID.Contains(carProperties.ID));
                _itemsByID.Add(carProperties.ID, newItem);
            }
        }

        private void ReloadItem(AddNewItemToInventorySignal signal)
        {
            _itemsByID[signal.NewItemID].ReloadItemButtons(_inventory._isOwnedItemsID.Contains(signal.NewItemID));
        }
    }
}