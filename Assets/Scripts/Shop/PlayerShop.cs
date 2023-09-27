using System;
using System.Collections.Generic;
using Player;
using Player.Inventory;
using Services;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class PlayerShop : MonoBehaviour
    {
        [SerializeField] private ShopItemList carPropertiesList;
        [SerializeField] private ShopItem shopItem;
        [SerializeField] private Transform shopContentList;
        private PlayerCarsTypes _currentSelectedItemType;

        private Dictionary<PlayerCarsTypes, ShopItem> _itemsByType = new Dictionary<PlayerCarsTypes, ShopItem>();
        private PlayerInventory _inventory;
        private EventBus _eventBus;
        private SaveService<PlayerShopSaveProperties> _saveService;
        private PlayerSetup _playerSetup;
        private string SaveFilePath;

        [Inject]
        private void Construct(PlayerInventory inventory, EventBus eventBus, PlayerSetup playerSetup)
        {
            _inventory = inventory;
            _eventBus = eventBus;
            _playerSetup = playerSetup;
        }

        private void Start()
        {
            SaveFilePath = Application.persistentDataPath + "shop.cars";
            _saveService = new SaveService<PlayerShopSaveProperties>(SaveFilePath);

            _eventBus.Subscribe<AddNewItemToInventorySignal>(ReloadItem, 0);
            _eventBus.Subscribe<SelectNewItemSignal>(ReloadItem, 0);
            LoadItemList();
        }

        private void LoadItemList()
        {
            foreach (var carProperties in carPropertiesList.carPropertiesList)
            {
                var newItem = Instantiate(shopItem, shopContentList);
                if (_inventory.OwnedItemsTypes.Contains(carProperties.type))
                {
                    newItem.SetItem(carProperties, ShopItemState.AbleToSelect);
                }
                else
                {
                    newItem.SetItem(carProperties, ShopItemState.AbleToBuy);
                }
                _itemsByType.Add(carProperties.type, newItem);
            }

            _currentSelectedItemType = _saveService.LoadFromFile<PlayerShopSaveProperties>().selectedItem;
            _eventBus.Invoke(new SelectNewItemSignal(carPropertiesList.FindCarByType(_currentSelectedItemType)));
        }

        private void ReloadItem(AddNewItemToInventorySignal signal)
        {
            _itemsByType[signal.NewCarType].ReloadItemButtons(ShopItemState.AbleToSelect);
        }

        private void ReloadItem(SelectNewItemSignal signal)
        {
            _itemsByType[_currentSelectedItemType].ReloadItemButtons(ShopItemState.AbleToSelect);
            _itemsByType[signal.CarProperties.type].ReloadItemButtons(ShopItemState.Selected); 
            _playerSetup.SetPlayer(carPropertiesList.FindCarByType(signal.CarProperties.type));
            _currentSelectedItemType = signal.CarProperties.type;
            SavePlayerShopProperties();
        }

        private void SavePlayerShopProperties()
        {
            _saveService.SaveToFile(new PlayerShopSaveProperties(_currentSelectedItemType));
        }
    }

    [Serializable]
    public struct PlayerShopSaveProperties
    {
        public PlayerCarsTypes selectedItem;

        public PlayerShopSaveProperties(PlayerCarsTypes newSelectedItem)
        {
            selectedItem = newSelectedItem;
        }
    }
}