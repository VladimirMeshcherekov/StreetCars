using System;
using CustomPool;
using NPC.Car;
using UnityEngine;

namespace NPC
{
    [Serializable]
    public class NpcPoolController
    {
        [SerializeField] private Vehicle[] vehiclesTypes;
        [SerializeField] private int poolCapacity;
        private CustomPool<Vehicle> _vehiclePool;
        public void Init()
        {
            _vehiclePool = new CustomPool<Vehicle>(vehiclesTypes, poolCapacity);
        }

        public Vehicle TyrGetVehicle()
        {
            return _vehiclePool.Get();
        }
    }
}