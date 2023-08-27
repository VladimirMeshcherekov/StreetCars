using Cinemachine;
using Player.Input;
using UnityEngine;
using VehicleBehaviour;

namespace Player
{
    public class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private WheelVehicle vehicle;
        [SerializeField] private Transform spawnPlayerPosition;
        [SerializeField] private CinemachineVirtualCamera followCamera;

        private PlayerMoveInput _playerMoveInput;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
           var spawnedVehicle = Instantiate(vehicle, spawnPlayerPosition.position,  Quaternion.Euler(0, 90, 0));
            _playerMoveInput = new PlayerMoveInput(spawnedVehicle);
            followCamera.Follow = spawnedVehicle.transform;
            followCamera.LookAt = spawnedVehicle.transform;
        }
    }
}