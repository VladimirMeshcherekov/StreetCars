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

        private PlayerInventory _inventory;

        [Inject]
        private void Construct(PlayerInventory inventory)
        {
            _inventory = inventory;
        }

        private void Start()
        {
            foreach (var carProperties in carPropertiesList.carPropertiesList)
            {
                var newItem = Instantiate(shopItem, shopContentList);
                newItem.SetItem(carProperties, _inventory._isOwnedItemsID.Contains(carProperties.ID));
            }
        }
    }
}