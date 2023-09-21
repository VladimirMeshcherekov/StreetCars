using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car Properties", menuName = "ScriptableObjects/Shop", order = 1)]
public class ShopItemList : ScriptableObject
{
    public List<CarProperties> carPropertiesList;
}
