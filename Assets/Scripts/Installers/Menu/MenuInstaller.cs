using Player;
using Zenject;

namespace Installers.Menu
{
    public class MenuInstaller : MonoInstaller
    {
        private PlayerInventory _playerInventory;
        public override void InstallBindings()
        {
            _playerInventory = new PlayerInventory();
            Container.BindInstance(_playerInventory).AsSingle().NonLazy();
        }
    }
}
