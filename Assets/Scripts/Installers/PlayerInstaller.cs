using Generate_Environment;
using NPC;
using Player.Input;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [FormerlySerializedAs("environmentSpawner")] [SerializeField] private LevelGenerator levelGenerator;
        [SerializeField] private Joystick playerJoystick;
        [SerializeField] private NpcPoolController npcPool;
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
            Container.BindInstance(levelGenerator).AsSingle();
            Container.Bind<NpcPoolController>().FromInstance(npcPool).AsSingle().NonLazy();
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