using Cinemachine;
using Player.Input;
using Player.Pause.Interfaces;
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
        private IPauseHandler _pauseHandler;

        [Inject]
        private void Construct(PlayerMove playerMove, IPauseHandler pauseHandler)
        {
            _playerMove = playerMove;
            _pauseHandler = pauseHandler;
        }

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var spawnedVehicle = Instantiate(vehicle, spawnPlayerPosition.position, Quaternion.Euler(0, 90, 0));
            _playerMove.Setup(spawnedVehicle, _pauseHandler);
            followCamera.Follow = spawnedVehicle.transform;
            followCamera.LookAt = spawnedVehicle.transform;
        }
    }
}