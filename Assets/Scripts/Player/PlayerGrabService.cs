using Player.Interfaces;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(WheelVehicle))]
    public class PlayerGrabService : MonoBehaviour
    {
        private WheelVehicle _vehicle;
        private PlayerSystem _playerSystem;

        [Inject]
        private void Construct(PlayerSystem playerSystem)
        {
            _playerSystem = playerSystem;
        }

        private void Start()
        {
            _vehicle = GetComponent<WheelVehicle>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamagePlayer npcCar))
            {
                _playerSystem.SetDamage((int)_vehicle.Speed);
            }
        }
    }
}