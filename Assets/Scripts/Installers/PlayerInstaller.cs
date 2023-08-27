using Generate_Environment;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private EnvironmentSpawner environmentSpawner;
        public override void InstallBindings()
        {
            Container.BindInstance(environmentSpawner).AsSingle();
        }
    }
}