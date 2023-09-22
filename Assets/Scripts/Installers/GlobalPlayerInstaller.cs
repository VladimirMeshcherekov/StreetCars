using Player;
using Zenject;

namespace Installers
{
    public class GlobalPlayerInstaller : MonoInstaller
    {
       // private PlayerSystem _playerSystem;
       private PlayerWallet _playerWallet;
        public override void InstallBindings()
        {
            _playerWallet = new PlayerWallet();
            Container.Bind<PlayerWallet>().FromInstance(_playerWallet).AsSingle().NonLazy();
            _playerWallet.TryAddCoins(100);
            //  _playerSystem = new PlayerSystem();
            //  Container.Bind<PlayerSystem>().FromInstance(_playerSystem).AsSingle().NonLazy();

        }
    }
}