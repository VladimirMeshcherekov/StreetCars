using CustomPool;
using NPC.Car;
using UnityEngine;

namespace NPC
{
    public class NpcPoolController : MonoBehaviour
    {
        [SerializeField] private Vehicle[] vehiclesTypes;
        [SerializeField] private int poolCapacity;
        private CustomPool<Vehicle> _pool;
        private void Start()
        {
            _pool = new CustomPool<Vehicle>(vehiclesTypes, poolCapacity);
        }

        public Vehicle TyrGetVehicle()
        {
            return _pool.Get();
        }
    }
}