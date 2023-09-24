using System;
using System.Collections.Generic;
using Player;
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
        private int _currentSelectedItemID;

        private Dictionary<int, ShopItem> _itemsByID = new Dictionary<int, ShopItem>();
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
                newItem.SetItem(carProperties, _inventory.IsOwnedItemsID.Contains(carProperties.ID));
                _itemsByID.Add(carProperties.ID, newItem);
            }

            _currentSelectedItemID = _saveService.LoadFromFile<PlayerShopSaveProperties>().selectedItem;
            _eventBus.Invoke(new SelectNewItemSignal(carPropertiesList.FindCarByID(_currentSelectedItemID)));
        }

        private void ReloadItem(AddNewItemToInventorySignal signal)
        {
            _itemsByID[signal.NewItemID].ReloadItemButtons(ShopItemState.AbleToSelect);
        }

        private void ReloadItem(SelectNewItemSignal signal)
        {
            _itemsByID[_currentSelectedItemID].ReloadItemButtons(ShopItemState.AbleToSelect);
            _itemsByID[signal.CarProperties.ID].ReloadItemButtons(ShopItemState.Selected); 
            _playerSetup.SetPlayer(carPropertiesList.FindCarByID(signal.CarProperties.ID));
            _currentSelectedItemID = signal.CarProperties.ID;
            SavePlayerShopProperties();
        }

        private void SavePlayerShopProperties()
        {
            _saveService.SaveToFile(new PlayerShopSaveProperties(_currentSelectedItemID));
        }
    }

    [Serializable]
    public struct PlayerShopSaveProperties
    {
        public int selectedItem;

        public PlayerShopSaveProperties(int newSelectedItem)
        {
            selectedItem = newSelectedItem;
        }
    }
}