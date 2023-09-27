using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GlobalPlayerInstaller : MonoInstaller
    {
        private PlayerWallet _playerWallet;
        [SerializeField] private PlayerSetup playerSetup;

        public override void InstallBindings()
        {
            _playerWallet = new PlayerWallet();
            Container.Bind<PlayerWallet>().FromInstance(_playerWallet).AsSingle().NonLazy();
            Container.Bind<PlayerSetup>().FromInstance(playerSetup).AsSingle().NonLazy();
        }
    }
}