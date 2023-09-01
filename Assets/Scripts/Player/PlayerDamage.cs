using Player.Interfaces;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(WheelVehicle))]
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private int toughness;
        private WheelVehicle _vehicle;
        private EventBus _eventBus;

        [Inject]
        void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void Start()
        {
            _vehicle = GetComponent<WheelVehicle>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamagePlayer npcCar))
            {
                toughness -= (int)_vehicle.Speed;
                print(toughness);
            }
        }
    }
}