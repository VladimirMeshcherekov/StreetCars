using Player.Interfaces;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(WheelVehicle))]
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private int maxPlayerHealth;
        private int _currentPlayerHealth;
        private WheelVehicle _vehicle;
        private EventBus _eventBus;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void Start()
        {
            _currentPlayerHealth = maxPlayerHealth;
            _eventBus.Invoke(new PlayerHealthChangedSignal(maxPlayerHealth, _currentPlayerHealth));
            _vehicle = GetComponent<WheelVehicle>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IDamagePlayer npcCar))
            {
                _currentPlayerHealth -= (int)_vehicle.Speed;
                _eventBus.Invoke(new PlayerHealthChangedSignal(maxPlayerHealth, _currentPlayerHealth));
                if (_currentPlayerHealth <= 0)
                {
                    _eventBus.Invoke(new PlayerDiedSignal());
                    _eventBus.Invoke(new SetNewPauseStateSignal(true));
                }
            }
        }
    }
}