using Zenject;

namespace Installers
{
    public class ArchitectureInstaller : MonoInstaller
    {
        private EventBus _eventBus;
        public override void InstallBindings()
        {
            _eventBus = new EventBus();
            Container.BindInstance(_eventBus).AsSingle();
        }
    }
}