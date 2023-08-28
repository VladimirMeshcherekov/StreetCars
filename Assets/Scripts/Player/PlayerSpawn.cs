using Cinemachine;
using Player.Input;
using UnityEngine;
using VehicleBehaviour;
using Zenject;

namespace Player
{
    public class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private WheelVehicle vehicle;
        [SerializeField] private Transform spawnPlayerPosition;
        [SerializeField] private CinemachineVirtualCamera followCamera;

        private PlayerMove _playerMove;
        private EventBus _eventBus;

        [Inject]
        private void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
           var spawnedVehicle = Instantiate(vehicle, spawnPlayerPosition.position,  Quaternion.Euler(0, 90, 0));
            _playerMove = new PlayerMove(spawnedVehicle, _eventBus);
            followCamera.Follow = spawnedVehicle.transform;
            followCamera.LookAt = spawnedVehicle.transform;
        }
    }
}