using Generate_Environment;
using Player.Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private EnvironmentSpawner environmentSpawner;
        public override void InstallBindings()
        {
            var EventBus = new EventBus();
            var _input =  new StandalonePlayerInput(EventBus);
            Container.BindInstance(environmentSpawner).AsSingle();
            Container.BindInstance(EventBus).AsSingle();;
        }
    }
}