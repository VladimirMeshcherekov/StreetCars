using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Car Properties", menuName = "ScriptableObjects/Shop", order = 1)]
public class ShopItemList : ScriptableObject
{
    public List<CarProperties> carPropertiesList;
    
    public CarProperties FindCarByID(int ID)
    {
        foreach (var car in carPropertiesList.Where(car => car.ID == ID))
        {
            return car;
        }

        throw new Exception("unable to find car with id " + ID);
    }
}
