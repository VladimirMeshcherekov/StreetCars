using Cinemachine;
using Player.Input;
using Player.Pause.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private Transform spawnPlayerPosition;
        [SerializeField] private CinemachineVirtualCamera followCamera;

        private PlayerMove _playerMove;
        private IPauseHandler _pauseHandler;
        private PlayerSetup _playerSetup;
        private PlayerHealth _playerHealth;
        private EventBus _eventBus;
        
        [Inject]
        private void Construct(PlayerMove playerMove, IPauseHandler pauseHandler, EventBus eventBus, PlayerHealth playerHealth, PlayerSetup playerSetup)
        {
            _eventBus = eventBus;
            _playerMove = playerMove;
            _pauseHandler = pauseHandler;
            _playerSetup = playerSetup;
            _playerHealth = playerHealth;
        }

        private void Start()
        {
            if (_playerSetup == null)
            {
                print(312);
            }
            
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var spawnedVehicle = Instantiate(_playerSetup.GetPlayer().carPrefab, spawnPlayerPosition.position, Quaternion.Euler(0, 90, 0));
            _playerMove.Setup(spawnedVehicle, _pauseHandler);
            _playerHealth.SetupPlayer(_eventBus, _playerSetup.GetPlayer().maxHealth);
            
            followCamera.Follow = spawnedVehicle.transform;
            followCamera.LookAt = spawnedVehicle.transform;
            Time.timeScale = 1;
        }
    }
}