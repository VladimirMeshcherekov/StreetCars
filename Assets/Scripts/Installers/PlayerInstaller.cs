using Generate_Environment;
using Player.Input;
using Player.Interfaces;
using SimpleInputNamespace;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Joystick playerJoystick;
        private PlayerMove _playerMove;
        private IMovePlayerInput _playerInput;

        public override void InstallBindings()
        {
            InstallMobileInput();
            _playerMove = new PlayerMove(_playerInput);
            Container.Bind<ITickable>().FromInstance(_playerMove).AsSingle().NonLazy();
            Container.Bind<PlayerMove>().FromInstance(_playerMove).AsSingle().NonLazy();
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