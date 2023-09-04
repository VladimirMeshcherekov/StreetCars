using System.Collections.Generic;
using Player;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class PlayerShop : MonoBehaviour
    {
        [SerializeField] private List<CarProperties> carPropertiesList;
        [SerializeField] private ShopItem shopItem;
        [SerializeField] private Transform shopContentList;

        private PlayerSystem _playerSystem;

        [Inject]
        private void Construct(PlayerSystem playerSystem)
        {
            _playerSystem = playerSystem;
        }

        private void Start()
        {
            foreach (var carProperties in carPropertiesList)
            {
                var newItem = Instantiate(shopItem, shopContentList);
                newItem.SetItem(carProperties, _playerSystem.Inventory._isOwnedItemsID.Contains(carProperties.ID));
            }
        }
    }
}