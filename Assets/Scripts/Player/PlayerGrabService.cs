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
        private PlayerHealth _playerHealth;

        [Inject]
        private void Construct(PlayerHealth playerHealth)
        { 
            _playerHealth = playerHealth;
        }

        private void Start()
        {
            _vehicle = GetComponent<WheelVehicle>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamagePlayer damageableObject))
            {
                _playerHealth.SetDamage((int)_vehicle.Speed);
            }
        }
    }
}