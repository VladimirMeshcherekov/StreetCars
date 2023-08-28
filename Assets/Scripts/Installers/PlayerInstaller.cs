using Generate_Environment;
using Player.Input;
using SimpleInputNamespace;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private EnvironmentSpawner environmentSpawner;
        [SerializeField] private Joystick playerJoystick;
        private EventBus _eventBus;

        public override void InstallBindings()
        {
            InstallArchitectureComponents();
            InstallInput();
            InstallLevelGeneration();
        }

        private void InstallArchitectureComponents()
        {
            _eventBus = new EventBus();
            Container.BindInstance(_eventBus).AsSingle();
        }

        private void InstallInput()
        {
            InstallMobileInput();
            InstallStandaloneInput();
        }

        private void InstallLevelGeneration()
        {
            Container.BindInstance(environmentSpawner).AsSingle();
        }

        private void InstallStandaloneInput()
        {
            var standalonePlayerInput = new StandalonePlayerInput(_eventBus);
        }

        private void InstallMobileInput()
        {
            var joystickPlayerInput = new JoystickPlayerInput(_eventBus, playerJoystick);
            Container.Bind<ITickable>().FromInstance(joystickPlayerInput).AsSingle().NonLazy();
        }
    }
}