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

        [Inject]
        private void Construct(PlayerMove playerMove)
        {
            _playerMove = playerMove;
        }

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var spawnedVehicle = Instantiate(vehicle, spawnPlayerPosition.position, Quaternion.Euler(0, 90, 0));
            _playerMove.SetVehicle(spawnedVehicle);
            followCamera.Follow = spawnedVehicle.transform;
            followCamera.LookAt = spawnedVehicle.transform;
        }
    }
}