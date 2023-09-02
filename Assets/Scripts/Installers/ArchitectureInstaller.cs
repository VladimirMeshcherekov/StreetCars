using Player.Pause;
using Player.Pause.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ArchitectureInstaller : MonoInstaller
    {
        private EventBus _eventBus;
        [SerializeField] private CustomPauseManager pauseManager;

        public override void InstallBindings()
        {
            _eventBus = new EventBus();
            Container.BindInstance(_eventBus).AsSingle();
            Container.Bind<IPauseHandler>().FromInstance(pauseManager).AsSingle().NonLazy();
        }
    }
}