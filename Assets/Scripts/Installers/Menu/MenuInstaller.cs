using Player;
using Player.Inventory;
using Zenject;

namespace Installers.Menu
{
    public class MenuInstaller : MonoInstaller
    {
        private PlayerInventory _playerInventory;
        private EventBus _eventBus;
        public override void InstallBindings()
        {
            _playerInventory = new PlayerInventory();
            _eventBus = new EventBus();
            
            Container.BindInstance(_playerInventory).AsSingle().NonLazy();
            Container.BindInstance(_eventBus).AsSingle().NonLazy();
        }
    }
}
