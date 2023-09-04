using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GlobalPlayerInstaller : MonoInstaller
    {
        private PlayerSystem _playerSystem;

        public override void InstallBindings()
        {
            _playerSystem = new PlayerSystem();
            Container.Bind<PlayerSystem>().FromInstance(_playerSystem).AsSingle().NonLazy();
        }
    }
}