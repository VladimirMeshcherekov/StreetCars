using Generate_Environment;
using Player.Input;
using Player.Interfaces;
using SimpleInputNamespace;
using UnityEngine;
using Zenject;
using Player;


namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Joystick playerJoystick;
        private PlayerMove _playerMove;
        private IMovePlayerInput _playerInput;
        private PlayerHealth _playerHealth;
     //   private PlayerSystem _player;

        public override void InstallBindings()
        {
           // _player = new PlayerSystem();
          //  Container.BindInstance(_player).AsSingle().NonLazy();
            
            InstallMobileInput();
            _playerMove = new PlayerMove(_playerInput);
            _playerHealth = new PlayerHealth();
            Container.Bind<ITickable>().FromInstance(_playerMove).AsSingle().NonLazy();
            Container.Bind<PlayerMove>().FromInstance(_playerMove).AsSingle().NonLazy();
            Container.Bind<PlayerHealth>().FromInstance(_playerHealth).AsSingle().NonLazy();
        }

        private void InstallStandaloneInput()
        {
            var standalonePlayerInput = new StandalonePlayerInput();
            Container.Bind<IMovePlayerInput>().FromInstance(standalonePlayerInput).AsSingle().NonLazy();
            _playerInput = standalonePlayerInput;
        }

        private void InstallMobileInput()
        {
            var joystickPlayerInput = new JoystickPlayerInput(playerJoystick);
            Container.Bind<IMovePlayerInput>().FromInstance(joystickPlayerInput).AsSingle().NonLazy();
            _playerInput = joystickPlayerInput;
        }
    }
}